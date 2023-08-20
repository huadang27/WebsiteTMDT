using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Models.ViewModel;
using example.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using Stripe.Checkout;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text.Json;
using example.Models.DTO;
using Microsoft.Extensions.Options;

namespace example_web_mvc.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;

        // rằng buộc dữ liệu databinding
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            //// xác thực người dùng chưa đăng nhập 
            // xác thực người dùng chưa đăng nhập 
            if (!User.Identity.IsAuthenticated)
            {
                //return Redirect($"/Identity/Account/Login?ReturnUrl=/Customer/Home/Details/?productId={productReviewVM.ProductId}");
                return Redirect($"/Login?ReturnUrl=/Customer/Cart/Index");

            }

            // lấy id người dùng
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            ShoppingCartVM = new ShoppingCartVM()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Product"),
                OrderHeader = new OrderHeader()
            };
            IEnumerable<ProductImage> productImages = _unitOfWork.ProductImage.GetAll();
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Product.ProductImages = productImages.Where(u => u.ProductId == cart.ProductId).ToList();
                cart.Price = GetPriceBaseOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartVM);
        }

        public IActionResult Summary()
        {

            // lấy id người dùng
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            ShoppingCartVM = new ShoppingCartVM()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Product"),
                OrderHeader = new OrderHeader()
            };


            // lấy thông tin giỏ hàng theo id người dùng đang đăng nhập 
            ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
            ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.ApplicationUser.Name;
            ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;
            ShoppingCartVM.OrderHeader.StreetAddress = ShoppingCartVM.OrderHeader.ApplicationUser.StreetAddress;
            ShoppingCartVM.OrderHeader.City = ShoppingCartVM.OrderHeader.ApplicationUser.City;
            ShoppingCartVM.OrderHeader.State = ShoppingCartVM.OrderHeader.ApplicationUser.State;
            ShoppingCartVM.OrderHeader.PostalCode = ShoppingCartVM.OrderHeader.ApplicationUser.PostCode;

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Price = GetPriceBaseOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartVM);
        }


        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {

            // lay du lieu cua nguoi dang dang nhap
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            ShoppingCartVM.ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Product");

            ShoppingCartVM.OrderHeader.OrderDate = System.DateTime.Now;
            ShoppingCartVM.OrderHeader.ApplicationUserId = userId;

            /*ShoppingCartVM.OrderHeader.ApplicationUser =_unitOfWork.ApplicationUser.Get(u=>u.Id==userId);*/

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);



            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Price = GetPriceBaseOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }
            var couponDiscount = 0.0;
            // Kiểm tra và áp dụng mã giảm giá (Coupon)
            if (!string.IsNullOrEmpty(ShoppingCartVM.CouponCode))
            {
                // Truy xuất mã giảm giá từ cơ sở dữ liệu
                //var coupon = _unitOfWork.Coupon.Get(u => u.Code == ShoppingCartVM.CouponCode);

                //if (coupon != null && coupon.IsActive && _unitOfWork.Coupon.IsCouponValid(coupon))
                //{
                //    //ShoppingCartVM.OrderHeader.OrderTotal -= CalculateCouponDiscount(coupon, ShoppingCartVM.OrderHeader.OrderTotal);
                //    //ShoppingCartVM.OrderHeader.CouponCode = coupon.Code;

                //    couponDiscount = _unitOfWork.Coupon.CalculateCouponDiscount(coupon, ShoppingCartVM.OrderHeader.OrderTotal);
                //    ShoppingCartVM.OrderHeader.OrderTotal -= couponDiscount;
                //    ShoppingCartVM.OrderHeader.CouponCode = coupon.Code;
                //}

                // Retrieve the coupon from the database
                var coupon = _unitOfWork.Coupon.Get(u => u.Code == ShoppingCartVM.CouponCode);

                if (coupon != null && _unitOfWork.Coupon.IsCouponValid(coupon, ShoppingCartVM.OrderHeader.OrderTotal))
                {
                    couponDiscount = _unitOfWork.Coupon.CalculateCouponDiscount(coupon, ShoppingCartVM.OrderHeader.OrderTotal);
                    ShoppingCartVM.OrderHeader.OrderTotal -= couponDiscount;
                    ShoppingCartVM.OrderHeader.CouponCode = coupon.Code;
                }

            }

            if (applicationUser.CompanyId.GetValueOrDefault() == 0)
            {

                // it is regular custome account 
                ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
                ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusPending;
            }
            else
            {
                // it is a company use
                ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentsStatusDelayedPayment;
                ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusApproved;
            }
            _unitOfWork.OrderHeader.Add(ShoppingCartVM.OrderHeader);
            _unitOfWork.Save();




            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {


                OrderDetail orderDetail = new OrderDetail()
                {
                    ProductId = cart.ProductId,
                    OrderHeaderId = ShoppingCartVM.OrderHeader.Id,
                    Price = cart.Price,
                    Count = cart.Count
                };
                _unitOfWork.OrderDetail.Add(orderDetail);
                _unitOfWork.Save();
            }
            if (applicationUser.CompanyId.GetValueOrDefault() == 0)
            {

                // it is a regular customer account and we need to capture pay,emt
                //stripe logic   
                var domain = "https://localhost:7139/";

                var options = new SessionCreateOptions
                {
                    SuccessUrl = domain + $"customer/cart/OrderConfirmation?id={ShoppingCartVM.OrderHeader.Id}",
                    CancelUrl = domain + "customer/cart/index",

                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                };
                foreach (var item in ShoppingCartVM.ShoppingCartList)
                {


                    // Calculate the final price after applying the discount
                    var discountAmount = item.Price * (couponDiscount / 100);
                    var itemFinalPricePerUnit = item.Price - discountAmount;

                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long?)(itemFinalPricePerUnit * 100),
                            Currency = "vnd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Product.Title
                            }
                        },
                        Quantity = item.Count
                    };
                    options.LineItems.Add(sessionLineItem);
                }
                var service = new SessionService();
                Session session = service.Create(options);
                _unitOfWork.OrderHeader.UpdateStripePaymentId(ShoppingCartVM.OrderHeader.Id, session.Id, session.PaymentIntentId);
                _unitOfWork.Save();
                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);

            }

            return RedirectToAction(nameof(OrderConfirmation), new { id = ShoppingCartVM.OrderHeader.Id });

        }


        public IActionResult OrderConfirmation(int id)
        {

            //OrderHeader orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == id, includeProperties: "ApplicationUser");
            OrderHeader orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == id, includeProperties: "ApplicationUser,OrderDetails.Product");

            if (orderHeader.PaymentStatus != SD.PaymentsStatusDelayedPayment)
            {

                // this is an order by customer
                var service = new SessionService();
                Session session = service.Get(orderHeader.SessionId);
                if (session.PaymentStatus.ToLower() == "paid")
                {


                    _unitOfWork.OrderHeader.UpdateStripePaymentId(id, session.Id, session.PaymentIntentId);
                    _unitOfWork.OrderHeader.UpdateStatus(id, SD.StatusApproved, SD.PaymentStatusApproved);

                    // Cập nhật   Quantity của  Products
                    foreach (var orderDetail in orderHeader.OrderDetails)
                    {
                        orderDetail.Product.Quantity -= orderDetail.Count;
                        _unitOfWork.Product.Update(orderDetail.Product);
                    }

                    _unitOfWork.Save();

                }
                HttpContext.Session.Clear();

            }
            _emailSender.SendEmailAsync(orderHeader.ApplicationUser.Email, "New Order - Book", $"<p>New order create-{orderHeader.Id} </p>");
            //  _emailSender.SendEmailAsync(orderHeader.ApplicationUser.Email, "New order - Bulky book", $"<p> New Order Created -{orderHeader.Id}</p>");

            List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == orderHeader.ApplicationUserId).ToList();
            _unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
            _unitOfWork.Save();
            return View(id);
        }

        //public JsonResult Plus(int cartId)
        //{
        //    var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
        //    cartFromDb.Count += 1;
        //    _unitOfWork.ShoppingCart.Update(cartFromDb);
        //    _unitOfWork.Save();

        //    var result = new
        //    {
        //        success = true,
        //        message = "Successfully increased item count",
        //        itemCount = cartFromDb.Count,
        //    };

        //    return Json(result);
        //}

        //public JsonResult Minus(int cartId)
        //{
        //    var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId, tracked: true);
        //    if (cartFromDb.Count <= 1)
        //    {
        //        _unitOfWork.ShoppingCart.Remove(cartFromDb);
        //        HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart
        //           .GetAll(u => u.ApplicationUserId == cartFromDb.ApplicationUserId).Count() - 1);

        //    }
        //    else
        //    {
        //        cartFromDb.Count -= 1;
        //        _unitOfWork.ShoppingCart.Update(cartFromDb);

        //    }
        //    _unitOfWork.Save();

        //    var result = new
        //    {
        //        success = cartFromDb.Count > 0,
        //        message = cartFromDb.Count > 0 ? "Successfully decreased item count" : "Item removed",
        //        itemCount = cartFromDb.Count,
        //    };

        //    return Json(result);
        //}


        //public JsonResult Remove(int cartId)
        //{
        //    var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId, tracked: true);
        //    _unitOfWork.ShoppingCart.Remove(cartFromDb);
        //    HttpContext.Session.SetInt32(SD.SessionCart,
        //    _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == cartFromDb.ApplicationUserId).Count() - 1);

        //    _unitOfWork.Save();

        //    var result = new
        //    {
        //        success = true,
        //        message = "Item removed successfully"
        //    };

        //    return Json(result);
        //}


        public IActionResult Plus(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
            cartFromDb.Count += 1;
            _unitOfWork.ShoppingCart.Update(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId, tracked: true);
            if (cartFromDb.Count <= 1)
            {
                _unitOfWork.ShoppingCart.Remove(cartFromDb);
                HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart
                   .GetAll(u => u.ApplicationUserId == cartFromDb.ApplicationUserId).Count() - 1);

            }
            else
            {
                cartFromDb.Count -= 1;
                _unitOfWork.ShoppingCart.Update(cartFromDb);

            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId, tracked: true);

            _unitOfWork.ShoppingCart.Remove(cartFromDb);
            HttpContext.Session.SetInt32(SD.SessionCart,
             _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == cartFromDb.ApplicationUserId).Count() - 1);

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }


        // Tính giá tiền
        public double GetPriceBaseOnQuantity(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Count <= 50)
            {
                return shoppingCart.Product.Price;
            }
            else
            {
                if (shoppingCart.Count <= 100)
                {
                    return shoppingCart.Product.Price50;
                }
                else
                {
                    return shoppingCart.Product.Price100;
                }
            }
        }

        public IActionResult GetCartUser()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect($"/Login?ReturnUrl=/Customer/Cart/Index");
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var shoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Product,Product.ProductImages");
            List<ShoppingCartDTO> shoppingCartDtoList = new List<ShoppingCartDTO>();
            double orderTotal = 0;

            foreach (var cart in shoppingCartList)
            {
                var cartDto = new ShoppingCartDTO
                {
                    Id = cart.Id,
                    ProductId = cart.ProductId,
                    Count = cart.Count,
                    ProductTitle = cart.Product.Title,
                    Price = GetPriceBaseOnQuantity(cart),
                    QuantityProduct = cart.Product.Quantity,
                    ProductImages = cart.Product.ProductImages.Select(pi => new ProductImage
                    {
                        Id = pi.Id,
                        ImageUrl = pi.ImageUrl
                    }).ToList(),
                    ApplicationUserId = cart.ApplicationUserId
                };

                shoppingCartDtoList.Add(cartDto);
                orderTotal += (cartDto.Price * cartDto.Count);
            }

            var orderHeaderDto = new OrderHeaderDto
            {
                OrderTotal = orderTotal
            };

            return Json(new { ShoppingCart = shoppingCartDtoList, OrderHeader = orderHeaderDto });
        }





    }
}
