using Kernel;
using Kernel.Entities;
using Kernel.Filters;

namespace BLL.Models
{
    public class ArticleModel : GenericViewModel<Article>
    {
        public ArticleModel()
        {
            this.DataContext = new();
            this.IsNew = true;
        }

        public ArticleModel(CFilter filter)
        {
            this.DataContext = ServicesManager.DataBase.GetFirstEntity<Article>(filter);
        }

        public override bool IsModified(Article oldValue)
        {
            return !this.DataContext.Equals(oldValue);
        }
    }
}
