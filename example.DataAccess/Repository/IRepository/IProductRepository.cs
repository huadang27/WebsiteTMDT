using example.Models;
using example.Models.DTO;

namespace example.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {

        void Update(Product obj);
        IEnumerable<Product> GetProductsBySellerApplicationUserId(string applicationUserId);
        List<ProductWithTotalCount> GetTopOrderedProducts();
        List<ProductDTO> GetProductsByCategoryName(string categoryName);

        List<ProductWithTotalCount> GetProductCountAll();
    }
}
