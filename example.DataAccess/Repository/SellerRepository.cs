using example.DataAccess.Repository.IRepository;
using example.Models;
using example_web_mvc.DataAccess.Data;

namespace example.DataAccess.Repository
{
    public class SellerRepository : Repository<Seller>, ISellerRepository
    {
        private ApplicationDbContext _db;
        public SellerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Seller obj)
        {
            _db.Sellers.Update(obj);
        }
    }
}
