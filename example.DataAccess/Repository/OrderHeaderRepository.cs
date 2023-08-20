using example.DataAccess.Repository.IRepository;
using example.Models;
using example_web_mvc.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace example.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<OrderHeader> GetOrderHeadersForSeller(int sellerId)
        {
            return _db.OrderHeaders
                .Include(oh => oh.OrderDetails)
                .ThenInclude(od => od.Product)
                .Include(oh => oh.ApplicationUser)
                .Where(oh => oh.OrderDetails.Any(od => od.Product.SellerId == sellerId))
                .ToList();
        }

        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                // cap nhat trang thai don hang
                orderFromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    //cap nhat trang thai thanh toan
                    orderFromDb.PaymentStatus = paymentStatus;
                }

            }
        }

        // Cập nhật thanh toán và trạng thái thanh toán
        public void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
            {
                orderFromDb.SessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                orderFromDb.PaymentIntentId = paymentIntentId;
                orderFromDb.PaymentData = DateTime.Now;

            }
        }
    }
}
