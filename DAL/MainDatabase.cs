using Kernel;
using Kernel.Filters;
using Kernel.Interfaces;
using Kernel.Joins;
using Kernel.Orders;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL
{
    public class MainDatabase : IDAL
    {
        private readonly DataContext _context;

        public MainDatabase(DataContext context)
        {
            _context = context;
        }
        
        public bool Create<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete<T>(T entity) where T : Entity
        {
            var entityToDelete = _context.Set<T>().Find(entity);
            if (entityToDelete == null)
                return false;

            _context.Set<T>().Remove(entityToDelete);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateEntities<T>(IEnumerable<T> entity) where T : Entity
        {
            if(entity == null)
                return false;
            foreach (var e in entity)
            {
                var entityToUpdate = _context.Set<T>().Find(e);
                if (entityToUpdate == null)
                    continue;

                _context.Set<T>().Update(entityToUpdate);
                _context.Attach(entityToUpdate).State = EntityState.Modified;
            }

            _context.SaveChanges();
            return true;
        }

        public bool UpdateEntity<T>(T entity) where T : Entity
        {
            var entityToUpdate = _context.Set<T>().Find(entity);
            if (entityToUpdate == null)
                return false;

            _context.Set<T>().Update(entityToUpdate);
            _context.Attach(entityToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<T> GetAllEntities<T>(JoinDescriptor[] joins, CFilter filters, SortDirection[]? orders = null) where T : Entity
        {
            var query = _context.Set<T>().AsQueryable();

            query = ApplyJoins(query, joins);
            query = ApplyFilters(query, filters);
            if (orders != null)
                query = ApplyOrders(query, orders);

            return query.ToList();
        }

        public IEnumerable<T> GetAllEntities<T>(CFilter filters, SortDirection[]? orders = null) where T : Entity
        {
            var query = _context.Set<T>().AsQueryable();

            query = ApplyFilters(query, filters);
            if (orders != null)
                query = ApplyOrders(query, orders);

            return query.ToList();
        }

        public IEnumerable<T> GetAllEntities<T>(SortDirection[]? orders = null) where T : Entity
        {
            var query = _context.Set<T>().AsQueryable();
            if (orders != null)
                query = ApplyOrders(query, orders);

            return query.ToList();
        }

        public T GetFirstEntity<T>(CFilter? filter = null) where T : Entity
        {
            var query = _context.Set<T>().AsQueryable();
            if (filter != null)
                query = ApplyFilters(query, filter);

            return query.FirstOrDefault();
        }

        private IQueryable<T> ApplyJoins<T>(IQueryable<T> query, JoinDescriptor[] joins) where T : Entity
        {
            foreach (var join in joins)
            {
                var rightSet = _context.Set<T>();

                if (join.Type == JoinType.Inner)
                {
                    query = query.Join(
                        rightSet,
                        left => EF.Property<object>(left, join.Left.PropertyName),
                        right => EF.Property<object>(right, join.Right.PropertyName),
                        (left, right) => left
                    );
                }
                else if (join.Type == JoinType.Left)
                {
                    query = query.GroupJoin(
                        rightSet,
                        left => EF.Property<object>(left, join.Left.PropertyName),
                        right => EF.Property<object>(right, join.Right.PropertyName),
                        (left, rightGroup) => new { left, rightGroup }
                    ).SelectMany(
                        x => x.rightGroup.DefaultIfEmpty(),
                        (x, right) => x.left
                    );
                }
            }

            return query;
        }

        private IQueryable<T> ApplyOrders<T>(IQueryable<T> query, SortDirection[] orders) where T : Entity
        {
            IOrderedQueryable<T> orderedQuery = null;

            for (int i = 0; i < orders.Length; i++)
            {
                var order = orders[i];
                var columnDescriptor = order.Column;

                if (i == 0)
                {
                    orderedQuery = order.Direction == SortDirectionType.Ascending
                        ? query.OrderBy(e => EF.Property<object>(e, columnDescriptor.PropertyName))
                        : query.OrderByDescending(e => EF.Property<object>(e, columnDescriptor.PropertyName));
                }
                else
                {
                    orderedQuery = order.Direction == SortDirectionType.Ascending
                        ? orderedQuery.ThenBy(e => EF.Property<object>(e, columnDescriptor.PropertyName))
                        : orderedQuery.ThenByDescending(e => EF.Property<object>(e, columnDescriptor.PropertyName));
                }
            }

            return orderedQuery ?? query;
        }

        private IQueryable<T> ApplyFilters<T>(IQueryable<T> query, CFilter filters) where T : Entity
        {
            foreach (var filterItem in filters)
            {
                if (filterItem is CFilterItem.CFilterItemContainer container)
                {
                    query = ApplyFilters(query, container.Filter);
                }
                else if (filterItem is CFilterItem item)
                {
                    query = ApplyFilterItem(query, item);
                }
            }
            return query;
        }

        private IQueryable<T> ApplyFilterItem<T>(IQueryable<T> query, CFilterItem item) where T : Entity
        {
            switch (item.Filter)
            {
                case FilterType.Equal:
                    query = query.Where(e => EF.Property<object>(e, item.Left.ToString()).Equals(item.Right));
                    break;
                case FilterType.NotEqual:
                    query = query.Where(e => !EF.Property<object>(e, item.Left.ToString()).Equals(item.Right));
                    break;
                case FilterType.GreaterThan:
                    query = query.Where(e => CompareValues(EF.Property<object>(e, item.Left.ToString()), item.Right) > 0);
                    break;
                case FilterType.GreaterThanOrEqual:
                    query = query.Where(e => CompareValues(EF.Property<object>(e, item.Left.ToString()), item.Right) >= 0);
                    break;
                case FilterType.LessThan:
                    query = query.Where(e => CompareValues(EF.Property<object>(e, item.Left.ToString()), item.Right) < 0);
                    break;
                case FilterType.LessThanOrEqual:
                    query = query.Where(e => CompareValues(EF.Property<object>(e, item.Left.ToString()), item.Right) <= 0);
                    break;
                case FilterType.Like:
                    query = query.Where(e => EF.Property<string>(e, item.Left.ToString()).Contains(item.Right.ToString()));
                    break;
                case FilterType.NotLike:
                    query = query.Where(e => !EF.Property<string>(e, item.Left.ToString()).Contains(item.Right.ToString()));
                    break;
                case FilterType.In:
                    query = query.Where(e => ((IEnumerable<object>)item.Right).Contains(EF.Property<object>(e, item.Left.ToString())));
                    break;
                case FilterType.NotIn:
                    query = query.Where(e => !((IEnumerable<object>)item.Right).Contains(EF.Property<object>(e, item.Left.ToString())));
                    break;
                case FilterType.IsNull:
                    query = query.Where(e => EF.Property<object>(e, item.Left.ToString()) == null);
                    break;
                case FilterType.IsNotNull:
                    query = query.Where(e => EF.Property<object>(e, item.Left.ToString()) != null);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return query;
        }

        private int CompareValues(object left, object right)
        {
            if (left is IComparable comparableLeft && right is IComparable comparableRight)
            {
                return comparableLeft.CompareTo(comparableRight);
            }
            return 0;
        }
    }
}
