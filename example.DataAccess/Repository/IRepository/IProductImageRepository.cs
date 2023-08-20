using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {

        void Update(ProductImage obj);

    }
}
