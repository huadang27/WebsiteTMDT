using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {

        void Update(OrderHeader obj);

        // trang thai thanh toan
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);

        void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId);

        IEnumerable<OrderHeader> GetOrderHeadersForSeller(int sellerId);
    }
}
