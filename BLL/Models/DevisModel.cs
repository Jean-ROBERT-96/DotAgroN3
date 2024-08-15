using Kernel;
using Kernel.Entities;
using Kernel.Filters;

namespace BLL.Models
{
    public class DevisModel : GenericViewModel<Devis>
    {
        public DevisModel()
        {
            this.DataContext = new();
            this.IsNew = true;
        }

        public DevisModel(CFilter filter)
        {
            this.DataContext = ServicesManager.DataBase.GetFirstEntity<Devis>(filter);
        }

        public override bool IsModified(Devis oldValue)
        {
            return !this.DataContext.Equals(oldValue);
        }
    }
}
