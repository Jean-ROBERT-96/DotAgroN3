using Kernel;

namespace BLL
{
    public abstract class GenericViewModel
    {
        public string? ErrorMessage { get; protected set; }
        public bool IsNew { get; set; }
    }

    public abstract class GenericViewModel<T> : GenericViewModel where T : Entity
    {
        public T DataContext { get; set; }
        
        public abstract bool IsModified(T oldValue);

        public bool ExecuteCommand(GenericActionCommand<T> command)
        {
            if (command.CanExecute())
                return command.Execute();

            return false;
        }
    }
}
