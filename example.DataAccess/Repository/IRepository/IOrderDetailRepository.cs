using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {

        void Update(OrderDetail obj);

    
    }
}
