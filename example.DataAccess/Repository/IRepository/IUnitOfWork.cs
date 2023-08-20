namespace example.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IOrderDetailRepository OrderDetail { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IProductImageRepository ProductImage { get; }
        ICouponRepository Coupon { get; }
        IProductReviewRepository ProductReview { get; }
        ISellerRepository Seller { get; }
        IUserProductViewRepository UserProductView { get; }
        void Save();
    }
}
