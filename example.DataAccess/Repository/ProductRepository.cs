using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Models.DTO;
using example_web_mvc.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;

namespace example.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public List<ProductWithTotalCount> GetProductCountAll()
        {
            return _db.OrderDetails
            .GroupBy(od => od.ProductId)
            .Select(group => new
            {
                ProductId = group.Key,
                TotalCount = group.Sum(x => x.Count)
            })
            .Join(
                _db.Products.Include(p => p.ProductImages),
                od => od.ProductId,
                p => p.Id,
                (od, p) => new ProductWithTotalCount
                {
                    ProductDTO = new ProductDTO
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Author = p.Author,
                        Price100 = p.Price100,
                        // Copy other properties
                        ProductImages = p.ProductImages.Select(pi => new ProductImage
                        {
                            Id = pi.Id,
                            ImageUrl = pi.ImageUrl
                            // Copy other properties
                        }).ToList()
                    },
                    TotalCount = od.TotalCount
                }).ToList();

        }

        public List<ProductDTO> GetProductsByCategoryName(string categoryName)
        {
            IQueryable<Product> query = _db.Products
                                             .Include(p => p.Category)
                                             .Include(p => p.ProductImages);

            if (!string.IsNullOrEmpty(categoryName))
            {
                query = query.Where(p => p.Category.Name == categoryName);
            }
            var products =  query.OrderByDescending(p => p.PublishDate).ToList();

            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Title = p.Title,
          
                Author = p.Author,
                PublishDate = p.PublishDate,
              
                ListPrice = p.ListPrice,
             
                Price100 = p.Price100,
                CategoryName = p.Category?.Name,
                ProductImages = p.ProductImages.Select(pi => new ProductImage
                {
                    Id = pi.Id,
                    ImageUrl = pi.ImageUrl
                }).ToList()
            }).ToList();
        }

        public List<ProductDTO> GetProductsByPublishDateAndCategoryName(string ?categoryName)
        {
            var query = _db.Products
        .Include(p => p.ProductImages)
        .Include(p => p.Category)
        .Include(p => p.Seller)
        .OrderByDescending(p => p.PublishDate)
        .Select(p => new ProductDTO
        {
            Id = p.Id,
            Title = p.Title,
            Author = p.Author,
            PublishDate = p.PublishDate,
            ListPrice = p.ListPrice,
            Price100 = p.Price100,
            CategoryName = p.Category.Name,
            ProductImages = p.ProductImages.Select(pi => new ProductImage
            {
                Id = pi.Id,
                ImageUrl = pi.ImageUrl
            }).ToList()
        });

            if (categoryName != null)
            {
                query = query.Where(p => p.CategoryName == categoryName);
            }

            var products = query.ToList();

            return products;
        }

        public IEnumerable<Product> GetProductsBySellerApplicationUserId(string applicationUserId)
        {
            return _db.Products.Where(p => p.Seller.ApplicationUserId == applicationUserId).ToList();
        }

        public List<ProductWithTotalCount> GetTopOrderedProducts()
        {
            return _db.OrderDetails
            .GroupBy(od => od.ProductId)
            .Select(group => new
            {
                ProductId = group.Key,
                TotalCount = group.Sum(x => x.Count)
            })
            .OrderByDescending(x => x.TotalCount)
            .Join(
                _db.Products.Include(p => p.ProductImages),
                od => od.ProductId,
                p => p.Id,
                (od, p) => new ProductWithTotalCount
                {
                    ProductDTO = new ProductDTO
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Author = p.Author,
                        Price100 = p.Price100,
                        Quantity = p.Quantity,
                        // Copy other properties
                        ProductImages = p.ProductImages.Select(pi => new ProductImage
                        {
                            Id = pi.Id,
                            ImageUrl = pi.ImageUrl
                            // Copy other properties
                        }).ToList()
                    },
                    TotalCount = od.TotalCount
                }
    )
    .ToList();
        }

        public void Update(Product obj)
        {
            var objFormdb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFormdb != null)
            {
                objFormdb.Title = obj.Title;
                objFormdb.ISBN = obj.ISBN;
                objFormdb.Price = obj.Price;
                objFormdb.Price50 = obj.Price50;

                objFormdb.ListPrice = obj.ListPrice;
                objFormdb.Price100 = obj.Price100;
                objFormdb.Description = obj.Description;
                objFormdb.CategoryId = obj.CategoryId;
                objFormdb.Author = obj.Author;
                objFormdb.Quantity = obj.Quantity;
                objFormdb.ProductImages = obj.ProductImages;
                //objFormdb.ImageUrl = obj.ImageUrl;
                //if (obj.ImageUrl != null)
                //{
                //    objFormdb.ImageUrl = obj.ImageUrl;
                //}
            }
        }
    }
}