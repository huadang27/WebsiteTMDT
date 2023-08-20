using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface IUserProductViewRepository : IRepository<UserProductView>
    {

        void Update(UserProductView obj);


        Product GetProductById(int productId);

    }
}
