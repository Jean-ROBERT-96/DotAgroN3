namespace Kernel.Interfaces
{
    public struct TData;
    public interface IDAL
    {
        public void Create<T>() where T : Entity<TData>;
        public void UpdateEntity<T>(T entity) where T : Entity<TData>;
        public void UpdateEntities<T>(IEnumerable<T> entity) where T : Entity<TData>;
        public void Delete<T>(T entity) where T : Entity<TData>;
        public T GetFirstEntity<T>(int id) where T : Entity<TData>;
        public IEnumerable<T> GetAllEntities<T>() where T : Entity<TData>;
    }
}
