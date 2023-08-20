using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface ISellerRepository : IRepository<Seller>
    {

        void Update(Seller obj);

    }
}
