using Kernel;

namespace BLL
{
    public abstract class GenericActionCommand<T> where T : Entity
    {
        protected GenericViewModel<T> viewModel { get; init; }

        public GenericActionCommand(GenericViewModel<T> entityType)
        {
            viewModel = entityType;
        }

        public abstract bool CanExecute();
        public abstract void Execute();
    }
}
