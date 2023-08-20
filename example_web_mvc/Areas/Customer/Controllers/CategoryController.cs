using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace example_web_mvc.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            dynamic myModel = new ExpandoObject();
            myModel.CategoryName = _unitOfWork.Category.GetAll().ToList();
            myModel.AuthorTop8 = _unitOfWork.Product.GetTopOrderedProducts().Take(8);
            myModel.ProductAll = _unitOfWork.Product.GetAll(includeProperties: "Category,Seller,ProductImages").Take(12).ToList();
            return View(myModel);

        }


        //[HttpGet]
        //public IActionResult GetCategoryProduct(int startAt = 0, string categoryNames = "")
        //{
        //    var categories = categoryNames.Split(',').ToList();
        //    var productList = _unitOfWork.Product.GetAll(p => categories.Contains(p.Category.Name), includeProperties: "Category,ProductImages,Seller").Skip(startAt)
        //                .Select(p => new ProductDTO
        //        {
        //            Id = p.Id,
        //            Title = p.Title,
        //            Author = p.Author,
        //            ListPrice = p.ListPrice,
        //            Price100 = p.Price100,
        //            StoreName = p.Seller.StoreName,
        //            CategoryName=p.Category.Name,
        //            // Extract the image URLs
        //            ImageUrls = p.ProductImages.Select(i => i.ImageUrl).Take(12).ToList()
        //        }).Take(8);

        //    return Json(productList);
        //}

        //[HttpGet]
        //public IActionResult GetCategoryProduct(int startAt = 0, string categoryNames = "", string authors = "")
        //{
        //    var categories = categoryNames.Split(',').ToList();
        //    var authorList = authors.Split(',').ToList();

        //    var productList = _unitOfWork.Product
        //        .GetAll(p => categories.Contains(p.Category.Name) || authorList.Contains(p.Author),
        //                includeProperties: "Category,ProductImages,Seller")
        //        .Skip(startAt)
        //        .Select(p => new ProductDTO
        //        {
        //            Id = p.Id,
        //            Title = p.Title,
        //            Author = p.Author,
        //            ListPrice = p.ListPrice,
        //            Price100 = p.Price100,
        //            StoreName = p.Seller.StoreName,
        //            CategoryName = p.Category.Name,
        //            // Extract the image URLs
        //            ImageUrls = p.ProductImages.Select(i => i.ImageUrl).Take(12).ToList()
        //        }).Take(8);

        //    return Json(productList);
        //}


        [HttpGet]
        public IActionResult GetCategoryProduct(int startAt = 0, string categoryNames = "", string authors = "", string orderBy = "")
        {
            var categories = categoryNames.Split(',').ToList();
            var authorList = authors.Split(',').ToList();
            categories.RemoveAll(item => item == "");
            authorList.RemoveAll(item => item == "");

            var productQuery =
               (categories.Count == 0 && authorList.Count == 0)
          ? _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages,Seller").Skip(startAt)
          : _unitOfWork.Product.GetAll(p => categories.Equals(p.Category.Name) || authorList.Equals(p.Author), includeProperties: "Category,ProductImages,Seller").Skip(startAt);
            switch (orderBy)
            {
                case "Tên":
                    productQuery = productQuery.OrderBy(p => p.Title);
                    break;
                case "Mới":
                    productQuery = productQuery.OrderByDescending(p => p.PublishDate);
                    break;
                case "Cũ":
                    productQuery = productQuery.OrderBy(p => p.PublishDate);
                    break;
                case "Giá":
                    productQuery = productQuery.OrderBy(p => p.Price100);
                    break;
                default:
                    break;  // Do nothing, retain the original order
            }

            var productList = productQuery
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Title = p.Title,
                    Author = p.Author,
                    ListPrice = p.ListPrice,
                    Price100 = p.Price100,
                    StoreName = p.Seller.StoreName,
                    CategoryName = p.Category.Name,
                    // Extract the image URLs
                    ImageUrls = p.ProductImages.Select(i => i.ImageUrl).Take(12).ToList()
                }).Take(8);

            return Json(productList);
        }






        [HttpGet]
        public IActionResult SearchProduct(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                // Nếu ô input không có dữ liệu, trả về tất cả sản phẩm
                var productList = _unitOfWork.Product
                    .GetAll(includeProperties: "Category,ProductImages,Seller")
                    .Select(p => new ProductDTO
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Author = p.Author,
                        ListPrice = p.ListPrice,
                        Price100 = p.Price100,
                        StoreName = p.Seller.StoreName,
                        CategoryName = p.Category.Name,
                        ImageUrls = p.ProductImages.Select(i => i.ImageUrl).Take(12).ToList()
                    }).Take(8);

                return Json(productList);
            }
            else
            {
                // Nếu có tiêu chí tìm kiếm, trả về danh sách sản phẩm phù hợp
                var productList = _unitOfWork.Product
                    .GetAll(p => p.Title.Contains(searchTerm),
                            includeProperties: "Category,ProductImages,Seller")
                    .Select(p => new ProductDTO
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Author = p.Author,
                        ListPrice = p.ListPrice,
                        Price100 = p.Price100,
                        StoreName = p.Seller.StoreName,
                        CategoryName = p.Category.Name,
                        ImageUrls = p.ProductImages.Select(i => i.ImageUrl).Take(12).ToList()
                    }).Take(8);

                return Json(productList);
            }
        }



    }
}