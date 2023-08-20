using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Models.ViewModel;
using example.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace example_web_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    // cũng có thể cho từng hàm nhỏ 
    [Authorize(Roles = SD.Role_Admin)]

    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _userManager = userManager;

        }
        public IActionResult Index()
        {



            return View();
        }

        public IActionResult RoleManagment(string userId)
        {


            RoleManagmentVM RoleVM = new RoleManagmentVM()
            {
                ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId, includeProperties: "Company"),
                RoleList = _roleManager.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Name
                }),
                CompanyList = _unitOfWork.Company.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),

            };
            RoleVM.ApplicationUser.Role = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.Get(u => u.Id == userId))
                     .GetAwaiter().GetResult().FirstOrDefault();

            return View(RoleVM);
        }
        [HttpPost]

        public IActionResult RoleManagment(RoleManagmentVM roleManagmentVM)
        {

            string oldRole = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.Get(u => u.Id == roleManagmentVM.ApplicationUser.Id))
                    .GetAwaiter().GetResult().FirstOrDefault();

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == roleManagmentVM.ApplicationUser.Id);
            if (!(roleManagmentVM.ApplicationUser.Role == oldRole))
            {


                if (roleManagmentVM.ApplicationUser.Role == SD.Role_Company)
                {
                    applicationUser.CompanyId = roleManagmentVM.ApplicationUser.CompanyId;
                }
                if (oldRole == SD.Role_Company)
                {
                    applicationUser.CompanyId = null;
                }
                _unitOfWork.ApplicationUser.Update(applicationUser);
                _unitOfWork.Save();

                // xoa role cũ 
                _userManager.RemoveFromRoleAsync(applicationUser, oldRole).GetAwaiter().GetResult();

                // thay doi quyen
                _userManager.AddToRoleAsync(applicationUser, roleManagmentVM.ApplicationUser.Role).GetAwaiter().GetResult();

            }
            else
            {
                if (oldRole == SD.Role_Company && applicationUser.CompanyId != roleManagmentVM.ApplicationUser.CompanyId)
                {
                    applicationUser.CompanyId = roleManagmentVM.ApplicationUser.CompanyId;
                    _unitOfWork.ApplicationUser.Update(applicationUser);
                    _unitOfWork.Save();
                }
            }



            return RedirectToAction("Index");
        }



        #region API CALLS

        // https://localhost:7139/admin/company/getall
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserList = _unitOfWork.ApplicationUser.GetAll(includeProperties: "Company").ToList();

            foreach (var user in objUserList)
            {
                user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();

                if (user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
            }

            return Json(new
            {
                data = objUserList
            });

        }


        //[HttpPost]
        //public IActionResult LockUnLock([FromBody] string id)
        //{
        //    var objformDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
        //    if (objformDb == null)
        //    {
        //        return Json(new { success = false, message = "Error while   Lock UnLock" });
        //    }
        //    if (objformDb.LockoutEnd != null && objformDb.LockoutEnd > DateTime.Now)
        //    {
        //        objformDb.LockoutEnd = DateTime.Now;
        //    }
        //    else
        //    {
        //        objformDb.LockoutEnd = DateTime.Now.AddYears(1000);

        //    }
        //    _db.SaveChanges();
        //    return Json(new { success = true, message = "Operation   successful" });


        //}

        public IActionResult LockUnLock([FromBody] string id)
        {
            var objFromDb = _unitOfWork.ApplicationUser.Get(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Lock/Unlock" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;
                _unitOfWork.ApplicationUser.Update(objFromDb);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Lock successful" });
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
                _unitOfWork.ApplicationUser.Update(objFromDb);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Unlock successful" });
            }
        }


        #endregion

    }

}
