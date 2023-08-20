using example.DataAccess.Repository.IRepository;
using example.Models;
using example_web_mvc.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace example.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(OrderDetail obj)
        {
            _db.OrderDetails.Update(obj);
        }
     
    }
}
