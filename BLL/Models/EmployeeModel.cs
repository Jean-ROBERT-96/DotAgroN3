using Kernel;
using Kernel.Entities;
using Kernel.Filters;

namespace BLL.Models
{
    public class EmployeeModel : GenericViewModel<Employee>
    {
        public EmployeeModel()
        {
            this.DataContext = new();
            this.IsNew = true;
        }

        public EmployeeModel(CFilter filter)
        {
            this.DataContext = ServicesManager.DataBase.GetFirstEntity<Employee>(filter);
        }

        public override bool IsModified(Employee oldValue)
        {
            return !this.DataContext.Equals(oldValue);
        }
    }
}
