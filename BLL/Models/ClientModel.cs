using Kernel;
using Kernel.Entities;
using Kernel.Filters;

namespace BLL.Models
{
    public class ClientModel : GenericViewModel<Client>
    {
        public ClientModel()
        {
            this.DataContext = new();
            this.IsNew = true;
        }

        public ClientModel(CFilter filter)
        {
            this.DataContext = ServicesManager.DataBase.GetFirstEntity<Client>(filter);
        }

        public override bool IsModified(Client oldValue)
        {
            return !this.DataContext.Equals(oldValue);
        }
    }
}
