using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace example_web_mvc.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class UserProductReviewController : Controller
    {
        private IUnitOfWork _unitOfWork { get; set; }


        public UserProductReviewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public IActionResult Index()
        {
            var products = new List<Product>();

            // Lấy thông tin từ bảng UserProductView
            if (User.Identity.IsAuthenticated)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                var userViews = _unitOfWork.UserProductView.GetAll(u => u.ApplicationUserId == userId,includeProperties: "ProductImages");

                foreach (var view in userViews)
                {
                    var product = _unitOfWork.Product.Get(u => u.Id == view.ProductId);
                    if (product != null)
                    {
                        products.Add(product);
                    }
                }
            }
            else
            {
                // Lấy từ cookie
                foreach (var cookie in Request.Cookies)
                {
                    if (cookie.Key.StartsWith("ViewedProduct_"))
                    {
                        var productId = int.Parse(cookie.Key.Substring("ViewedProduct_".Length));
                        var product = _unitOfWork.Product.Get(u => u.Id == productId,includeProperties: "ProductImages");
                        if (product != null)
                        {
                            products.Add(product);
                        }
                    }
                }
            }

            return View(products); // Trả về view với danh sách sản phẩm
        }

    }
}
