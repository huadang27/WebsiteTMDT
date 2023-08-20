using example.DataAccess.Repository.IRepository;
using example.Models;
using example_web_mvc.DataAccess.Data;

namespace example.DataAccess.Repository
{
    public class ProductReviewRepository : Repository<ProductReview>, IProductReviewRepository
    {
        private ApplicationDbContext _db;
        public ProductReviewRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(ProductReview obj)
        {
            _db.ProductReviews.Update(obj);
        }
    }
}
