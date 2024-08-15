using Kernel;

namespace BLL.Commands
{
    public class UpdateCommand<T> : GenericActionCommand<T> where T : Entity
    {
        private readonly int _id;

        public UpdateCommand(GenericViewModel<T> entityType, int id) : base(entityType)
        {
            this._id = id;
        }

        public override bool CanExecute()
        {
            return true;
        }

        public override bool Execute()
        {
            return ServicesManager.DataBase.UpdateEntity(_id, viewModel.DataContext);
        }
    }
}
