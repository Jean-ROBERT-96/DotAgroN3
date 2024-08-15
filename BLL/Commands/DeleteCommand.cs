using Kernel;

namespace BLL.Commands
{
    public class DeleteCommand<T> : GenericActionCommand<T> where T : Entity
    {
        private readonly int _id;

        public DeleteCommand(GenericViewModel<T> entityType, int id) : base(entityType)
        {
            this._id = id;
        }

        public override bool CanExecute()
        {
            return true;
        }

        public override bool Execute()
        {
            return ServicesManager.DataBase.Delete<T>(_id);
        }
    }
}
