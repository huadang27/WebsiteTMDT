using example.DataAccess.Repository.IRepository;
using example.Models;
using example_web_mvc.DataAccess.Data;

namespace example.DataAccess.Repository
{
    public class CouponRepository : Repository<Coupon>, ICouponRepository
    {
        private ApplicationDbContext _db;
        public CouponRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Coupon obj)
        {
            _db.Coupons.Update(obj);
        }

        // mã giảm giá, và số tiền tối thiếu mã giảm giá có thể áp dụng được 
        public bool IsCouponValid(Coupon coupon, double currentTotal)
        {
            var currentDate = DateTime.Now;
            return coupon.IsActive
                   && currentDate >= coupon.StartDate
                   && currentDate <= coupon.EndDate
                   && coupon.UsedTimes < coupon.MaxUseTimes
                   && currentTotal >= coupon.MinimumSpend;
        }


        public double CalculateCouponDiscount(Coupon coupon, double orderTotal)
        {
            if (coupon.ApplyForAllProducts)
            {
                return coupon.DiscountAmount;
            }
            else
            {
                return orderTotal * (double)(coupon.DiscountAmount / 100);
            }
        }
    }
}
