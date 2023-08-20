using example.DataAccess.Repository;
using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace example_web_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public IActionResult Index()
        //{
        //    List<Category> obj = _unitOfWork.Category.GetAll().ToList();
        //    return View(obj);
        //}

        public ActionResult Index(int page, int size)
        {
            int pageSize = size > 0 ? size : 10;
            int pageNumber = page > 0 ? page : 1;

            var recruitments = _unitOfWork.Category.GetAll().ToList();
            var pagedList = new PagedList<Category>(recruitments, pageNumber, pageSize);
            return View(pagedList);
        }

        public IActionResult Create()
        {
            return View();
        }


    
        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            try
            {
                bool exists = _unitOfWork.Category.ExistsBy(c => c.Name.Equals(category.Name));
                if (exists)
                {
                    return BadRequest(new
                    {
                        message = "Tên  danh mục đã tồn tại"
                    });
                }
                else
                {
                    _unitOfWork.Category.Add(category);
                    _unitOfWork.Save();
                }

              
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }


            Category? category = _unitOfWork.Category.Get(u => u.Id == id);
            //Category? category1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? category2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }

            return Json(category);
        }


        [HttpPost]
        public IActionResult Edit([FromBody] Category obj)
        {


            if (ModelState.IsValid)
            {
                // thêm dữ liệu vào database
                _unitOfWork.Category.Update(obj);

                // lưu dữ liệu khi thêm
                _unitOfWork.Save();
                //TempData["success"] = "Category update successfully";
                return Ok(obj);
            }

            // return View();
            // Nếu dữ liệu không hợp lệ, quay lại modal chỉnh sửa
            return BadRequest();
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }


            Category? category = _unitOfWork.Category.Get(u => u.Id == id);
            //Category? category1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? category2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _unitOfWork.Category.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);

            _unitOfWork.Save();
            TempData["success"] = "Delete category successfully";

            return RedirectToAction("Index");

        }


        //tìm kiếm 
        public IActionResult Search(string name)
        {
            var results = _unitOfWork.Category.GetAll(u => u.Name.Contains(name));
            try
            {
                return Ok(results);
            }
            catch
            {
                return NotFound();
            }
        }




        //serverside category 
        [HttpPost]

        public IActionResult CreateCategory(Category Category)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Category.Add(Category);
                _unitOfWork.Save();
                TempData["success"] = "Thêm sản phẩm thành công";
                return RedirectToAction(nameof(Index));


            }
            return BadRequest(Category);
        }

        public IActionResult EditSV(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }
            var Category = _unitOfWork.Category.Get(u => u.Id == id);
            if (Category == null)
            {
                return NotFound();
            }
            return View("Edit", Category);
        }

        [HttpPost]
        public IActionResult SaveSV(Category Category)

        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(Category);
                _unitOfWork.Save();
                TempData["success"] = "Cập nhật thành công";
                return RedirectToAction(nameof(Index));

            }
            return View("Edit", Category);
        }




    }

}
