using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace example_web_mvc.Areas.Admin.Controllers
{


    [Area("Admin")]

    // cũng có thể cho từng hàm nhỏ 
    [Authorize(Roles = SD.Role_Admin)]
    public class CouponController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CouponController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            List<Coupon> obj = _unitOfWork.Coupon.GetAll().ToList();


            return View(obj);
        }

        public IActionResult Upsert(int? id)
        {




            if (id == 0 || id == null)
            {
                // create
                return BadRequest();
            }
            else
            {
                // update
                Coupon companyObj = _unitOfWork.Coupon.Get(u => u.Id == id);
                return View(companyObj);
            }

        }
        [HttpPost]
        public IActionResult Upsert([FromBody] Coupon couponObj)
        {

            if (ModelState.IsValid)
            {

                if (couponObj.Id == 0)
                {
                    // thêm dữ liệu vào database
                    _unitOfWork.Coupon.Add(couponObj);
                }
                else
                {
                    _unitOfWork.Coupon.Update(couponObj);
                }


                // lưu dữ liệu khi thêm
                _unitOfWork.Save();

                TempData["success"] = "Coupon created successfully";
                //return RedirectToAction("Index");
                return Ok(couponObj);
            }
            else
            {
                return BadRequest();
            }


        }

        #region API CALLS

        // https://localhost:7139/admin/coupon/getall
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Coupon> obj = _unitOfWork.Coupon.GetAll().ToList();
            return Json(new { data = obj });


        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDelete = _unitOfWork.Coupon.Get(u => u.Id == id);
            if (companyToBeDelete == null)
            {
                return Json(new { success = false, message = "Error while deleteing" });
            }


            _unitOfWork.Coupon.Remove(companyToBeDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete  successful" });

        }
        //http Post CouponController: Coupon/CheckCouponCode
        [HttpPost]
        public IActionResult CheckCouponCode(string couponCode, double currentTotal)
        {
            // Get the coupon from the database
            var coupon = _unitOfWork.Coupon.Get(c => c.Code == couponCode);

            if (coupon != null && _unitOfWork.Coupon.IsCouponValid(coupon, currentTotal))
            {
                // Coupon is valid, return the discount amount and update the use times
                coupon.UsedTimes++;
                _unitOfWork.Coupon.Update(coupon);
                _unitOfWork.Save();
                return Json(new { isValid = true, discountAmount = coupon.DiscountAmount });
            }
            else
            {
                // Coupon is not valid
                return Json(new { isValid = false });
            }
        }



        #endregion
    }
}
