using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Models.DTO;
using example.Models.ViewModel;
using example.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Security.Claims;

namespace example_web_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    // cũng có thể cho từng hàm nhỏ 0
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Seller)]

    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<Product> obj = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();


            return View(obj);
        }

        public IActionResult Upsert(int? id)
        {



            ProductVM productVM = new ProductVM
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            if (id == 0 || id == null)
            {
                // create
                return View(productVM);
            }
            else
            {
                // update
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id, includeProperties: "ProductImages");
                return View(productVM);
            }

        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, List<IFormFile>? files)
        {
            // lấy id người dùng
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var seller = _unitOfWork.Seller.Get(u => u.ApplicationUserId == userId);
            if (seller != null)
            {
                productVM.Product.SellerId = seller.Id;
                if (ModelState.IsValid)
                {

                    if (productVM.Product.Id == 0)
                    {
                        // thêm dữ liệu vào database
                        _unitOfWork.Product.Add(productVM.Product);
                    }
                    else
                    {
                        _unitOfWork.Product.Update(productVM.Product);
                    }


                    // lưu dữ liệu khi thêm
                    _unitOfWork.Save();

                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    if (files != null)
                    {
                        foreach (IFormFile file in files)
                        {
                            string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            string productPath = @"images\products\product-" + productVM.Product.Id;
                            string finalPath = Path.Combine(wwwRootPath, productPath);
                            if (!Directory.Exists(finalPath))
                            {
                                Directory.CreateDirectory(finalPath);
                            }
                            using (var fileStream = new FileStream(Path.Combine(finalPath, filename), FileMode.Create))
                            {
                                file.CopyTo(fileStream);

                            }
                            ProductImage productImage = new ProductImage()
                            {
                                ImageUrl = @"\" + productPath + @"\" + filename,
                                ProductId = productVM.Product.Id
                            };

                            if (productVM.Product.ProductImages == null)
                            {
                                productVM.Product.ProductImages = new List<ProductImage>();
                            }
                            // them du lieu anh vao mang
                            productVM.Product.ProductImages.Add(productImage);
                            //_unitOfWork.ProductImage.Add(productImage);

                        }
                        _unitOfWork.Product.Update(productVM.Product);
                        _unitOfWork.Save();


                    }


                    TempData["success"] = "Product created/update successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    // Hiển thị lỗi xác thực trong giao diện người dùng
                    foreach (var modelStateEntry in ModelState.Values)
                    {
                        foreach (var error in modelStateEntry.Errors)
                        {
                            string errorMessage = error.ErrorMessage;
                            // Xử lý thông báo lỗi theo ý của bạn, ví dụ: thêm vào ViewData hoặc hiển thị trực tiếp trong giao diện
                        }
                    }

                    productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });

                    return View(productVM);
                }
            }
            else
            {
                TempData["error"] = "Could not find associated seller. Please check your account.";
                return RedirectToAction("Index"); // hoặc đến trang quản lý seller tương ứng
            }



        }


        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted = _unitOfWork.ProductImage.Get(u => u.Id == imageId);
            int productId = imageToBeDeleted.ProductId;
            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldImageUrl = Path.Combine(_webHostEnvironment.WebRootPath, imageToBeDeleted.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImageUrl))
                    {

                        System.IO.File.Delete(oldImageUrl);

                    }
                }
                _unitOfWork.ProductImage.Remove(imageToBeDeleted);
                _unitOfWork.Save();
                TempData["success"] = "Delete successfuly";
            }
            return RedirectToAction(nameof(Upsert), new { id = productId });
        }


        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();

        //    }


        //    Product? product = _unitOfWork.Product.Get(u => u.Id == id);
        //    Product? product1 = _db.Categories.FirstOrDefault(u => u.Id == id);
        //    Product? product2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}


        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePost(int? id)
        //{
        //    Product? product = _unitOfWork.Product.Get(u => u.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Product.Remove(product);

        //    _unitOfWork.Save();
        //    TempData["success"] = "Delete product successfully";

        //    return RedirectToAction("Index");

        //}

        #region API CALLS

        // https://localhost:7139/admin/product/getall
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    var seller
        //    if (!User.IsInRole(SD.Role_Admin))
        //    {
        //         seller = _unitOfWork.Seller.Get(u => u.ApplicationUserId == userId);

        //    }

        //    //List<Product> obj = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
        //    List<Product> obj;

        //    if (seller != null)
        //    {
        //        obj = _unitOfWork.Product.GetAll(p => p.SellerId == seller.Id, includeProperties: "Category").ToList();
        //    }
        //    else
        //    {
        //        obj = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
        //    }

        //    return Json(new { data = obj });



        //}

        [HttpGet]
        public IActionResult GetAll()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            List<Product> obj;
            if (User.IsInRole(SD.Role_Admin))
            {
                obj = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            }
            else
            {
                var seller = _unitOfWork.Seller.Get(u => u.ApplicationUserId == userId);
                if (seller != null)
                {
                    obj = _unitOfWork.Product.GetAll(p => p.SellerId == seller.Id, includeProperties: "Category").ToList();
                }
                else
                {
                    obj = new List<Product>();
                }
            }

            return Json(new { data = obj });
        }


        [HttpGet]
        public IActionResult GetProductsBySeller()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
           

            var products = _unitOfWork.Product.GetProductsBySellerApplicationUserId(userId);

         

            return Json(new { data = products });
        }



        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDelete = _unitOfWork.Product.Get(u => u.Id == id);
            if (productToBeDelete == null)
            {
                return Json(new { success = false, message = "Error while deleteing" });
            }

            //var oldImageUrl = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDelete.ImageUrl.TrimStart('\\'));
            //if (System.IO.File.Exists(oldImageUrl))
            //{

            //    System.IO.File.Delete(oldImageUrl);

            //}
            string productPath = @"images\products\product-" + id;
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);
            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }
                Directory.Delete(finalPath);
            }
            _unitOfWork.Product.Remove(productToBeDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete  successful" });

           

        }

     

        #endregion

    }

}
