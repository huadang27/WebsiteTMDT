using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface ICouponRepository : IRepository<Coupon>
    {

        void Update(Coupon obj);
        bool IsCouponValid(Coupon coupon, double currentTotal);
        double CalculateCouponDiscount(Coupon coupon, double orderTotal);

    }
}
