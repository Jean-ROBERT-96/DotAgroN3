using Kernel;

namespace BLL
{
    public abstract class GenericActionCommand
    {
        public abstract bool CanExecute();
        public abstract bool Execute();
    }

    public abstract class GenericActionCommand<T> : GenericActionCommand where T : Entity
    {
        protected GenericViewModel<T> viewModel { get; init; }

        public GenericActionCommand(GenericViewModel<T> entityType)
        {
            viewModel = entityType;
        }
    }
}
