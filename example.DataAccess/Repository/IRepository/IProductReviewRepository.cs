using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface IProductReviewRepository : IRepository<ProductReview>
    {

        void Update(ProductReview obj);

    }
}
