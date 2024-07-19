using DemoGH__Tutor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace DemoGH__Tutor.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _db; // đại diện cho csdl
        //sửa ở đây
        public UserController(AppDbContext db)
        {
            _db = db;
        }

        //lấy ra tất cả danh sách user
        public IActionResult Index(string name) //=> day la hanh dong
        {
            //lấy giá trị sesion có tên là user
            var seesionData = HttpContext.Session.GetString("User");
            if(seesionData == null)
            {
                ViewData["message"] = "Chưa đăng nhập bạn ê";
            }
            else
            {
                ViewData["message"] = $"Chào mừng {seesionData} đến với bình nguyên vô tận ";

            }

            //lấy toàn bộ user
            var userData = _db.Users.ToList();

            //làm thêm tìm kiếm nhé
            //check xem name có rỗng hoặc null thì trả về toàn bộ dữ l;iệu còn k rỗng thì tìm kiếm
            if(string.IsNullOrEmpty(name))
            {
                return View(userData);
            }

            else
            {
                var userSearch = _db.Users.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
                //lưu số lượng tìm kiếm vào viewdata và viewbag
                ViewData["count"]= userSearch.Count;
                ViewBag.Count = userSearch.Count;
                if(userSearch.Count == 0) { return View(userData); }
                else
                {
                    return View(userSearch);
                }

            }



        }
    }
}
