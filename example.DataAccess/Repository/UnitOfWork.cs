using example.DataAccess.Repository.IRepository;
using example_web_mvc.DataAccess.Data;

namespace example.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork

    {

        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        public ICompanyRepository Company { get; private set; }

        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IProductImageRepository ProductImage { get; private set; }
        public ICouponRepository Coupon { get; private set; }


        public IProductReviewRepository ProductReview { get; private set; }

        public ISellerRepository Seller { get; private set; }

        public IUserProductViewRepository UserProductView { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ProductImage = new ProductImageRepository(_db);
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);

            OrderDetail = new OrderDetailRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            Coupon = new CouponRepository(_db);
            ProductReview = new ProductReviewRepository(_db);
            Seller = new SellerRepository(_db);
            UserProductView = new UserProductViewRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
