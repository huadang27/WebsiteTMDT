
using example.DataAccess.DbInitializer;
using example.Models;
using example.Utility;
using example_web_mvc.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer

    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
                RoleManager<IdentityRole> RoleManager,
                ApplicationDbContext db)
        {
            _roleManager = RoleManager;
            _userManager = userManager;
            _db = db;
        }
        public void Initialize()
        {
            // di chuyển nếu chúng không được áp dụng

            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }

            }
            catch (Exception)
            {

            }

            //tạo vai trò nếu chúng không được tạo

            if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Seller)).GetAwaiter().GetResult();


                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Name = "Tiến Nguyễn",
                    PhoneNumber = "0346790482",
                    StreetAddress = "Hoàng Mai",
                    State = "VN",
                    PostCode = "100000",
                    City = "Hà Nội"
                }, "Tien1234@").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@gmail.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }

            // nếu vai trò không được tạo, thì chúng tôi cũng sẽ tạo người dùng quản trị
            return;

        }
    }
}