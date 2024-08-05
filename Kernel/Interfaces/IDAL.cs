using Kernel.Filters;
using Kernel.Joins;
using Kernel.Orders;

namespace Kernel.Interfaces
{
    public interface IDAL
    {
        public bool Create<T>(T entity) where T : Entity;
        public bool UpdateEntity<T>(T entity) where T : Entity;
        public bool UpdateEntities<T>(IEnumerable<T> entity) where T : Entity;
        public bool Delete<T>(T entity) where T : Entity;
        public T GetFirstEntity<T>(CFilter? filter = null) where T : Entity;
        public IEnumerable<T> GetAllEntities<T>(JoinDescriptor[] joins, CFilter filters, SortDirection[]? orders = null) where T : Entity;
        public IEnumerable<T> GetAllEntities<T>(CFilter filters, SortDirection[]? orders = null) where T : Entity;
        public IEnumerable<T> GetAllEntities<T>(SortDirection[]? orders = null) where T : Entity;
    }
}
