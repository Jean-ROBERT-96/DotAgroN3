using Kernel;
using Kernel.Entities;
using Kernel.Filters;

namespace BLL.Models
{
    public class FactureModel : GenericViewModel<Facture>
    {
        public FactureModel()
        {
            this.DataContext = new();
            this.IsNew = true;
        }

        public FactureModel(CFilter filter)
        {
            this.DataContext = ServicesManager.DataBase.GetFirstEntity<Facture>(filter);
        }

        public override bool IsModified(Facture oldValue)
        {
            return !this.DataContext.Equals(oldValue);
        }
    }
}
