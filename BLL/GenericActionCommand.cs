using Kernel;

namespace BLL
{
    public abstract class GenericActionCommand<T> where T : Entity
    {
        public Type EntityType => typeof(T);

        public abstract bool CanExecute();
        public abstract void Execute();
    }
}
