using Kernel;
using Kernel.Entities;
using Kernel.Filters;

namespace BLL.Models
{
    public class SocieteModel : GenericViewModel<Societe>
    {
        public SocieteModel()
        {
            this.DataContext = new();
            this.IsNew = true;
        }

        public SocieteModel(CFilter filter)
        {
            this.DataContext = ServicesManager.DataBase.GetFirstEntity<Societe>(filter);
        }

        public override bool IsModified(Societe oldValue)
        {
            return !this.DataContext.Equals(oldValue);
        }
    }
}
