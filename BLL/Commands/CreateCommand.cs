using Kernel;
using Kernel.Entities;

namespace BLL.Commands
{
    internal class CreateCommand<T> : GenericActionCommand<T> where T : Adresse
    {
        public CreateCommand(GenericViewModel<T> entityType) : base(entityType)
        {
        }

        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {
            ServicesManager.DataBase.Create(viewModel.DataContext);
        }
    }
}
