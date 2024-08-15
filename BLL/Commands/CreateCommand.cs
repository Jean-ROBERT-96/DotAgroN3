using Kernel;

namespace BLL.Commands
{
    public class CreateCommand<T> : GenericActionCommand<T> where T : Entity
    {
        public CreateCommand(GenericViewModel<T> entityType) : base(entityType)
        {
        }

        public override bool CanExecute()
        {
            return true;
        }

        public override bool Execute()
        {
            if (ServicesManager.DataBase.Create(viewModel.DataContext))
            {
                viewModel.IsNew = false;
                return true;
            }
            return false;
        }
    }
}
