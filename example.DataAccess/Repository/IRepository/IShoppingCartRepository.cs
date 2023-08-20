using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {

        void Update(ShoppingCart obj);

    }
}
