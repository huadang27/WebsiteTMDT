using example.DataAccess.Repository.IRepository;
using example.Models;
using example_web_mvc.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace example.DataAccess.Repository
{
    public class UserProductViewRepository : Repository<UserProductView>, IUserProductViewRepository
    {
        private ApplicationDbContext _db;
        public UserProductViewRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Product GetProductById(int productId)
        {
            return _db.Products.Include("Category").Include("ProductImages").Include("Seller").FirstOrDefault(p => p.Id == productId);
        }

        public void Update(UserProductView obj)
        {
            _db.UserProducts.Update(obj);
        }
    }
}
