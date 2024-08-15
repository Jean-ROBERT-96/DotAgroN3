using Kernel;

namespace BLL
{
    public abstract class GenericViewModel<T> where T : Entity
    {
        public T DataContext { get; set; }
        public string? ErrorMessage { get; protected set; }

        public abstract bool IsModified(T oldValue);
    }
}
