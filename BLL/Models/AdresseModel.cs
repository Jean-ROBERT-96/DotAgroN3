using BLL.Commands;
using Kernel;
using Kernel.Entities;
using Kernel.Filters;

namespace BLL.Models
{
    public class AdresseModel : GenericViewModel<Adresse>
    {
        public CreateCommand<Adresse> CreateCommand { get; set; }
        public UpdateCommand<Adresse> UpdateCommand { get; set; }
        public DeleteCommand<Adresse> DeleteCommand { get; set; }

        public AdresseModel()
        {
            this.DataContext = new();
            this.IsNew = true;
        }

        public AdresseModel(CFilter filter)
        {
            this.DataContext = ServicesManager.DataBase.GetFirstEntity<Adresse>(filter);
        }

        public override bool IsModified(Adresse oldValue)
        {
            return !this.DataContext.Equals(oldValue);
        }
    }
}
