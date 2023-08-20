using example.Models;
using System.Linq.Expressions;

namespace example.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {

        void Update(Category obj);

        bool ExistsBy(Expression<Func<Category, bool>> filter);

    }
}
