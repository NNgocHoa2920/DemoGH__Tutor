using DemoGH__Tutor.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoGH__Tutor.Controllers
{
    public class GHCTController : Controller
    {
        AppDbContext _db; // biến toàn cục thường sẽ đến dấu _ 
        public GHCTController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("username");
            //check xem đăng nhập hay chưa, đăng thì mới cho xem
            if(user == null)
            {
                return Content("Đăng nhập đê");
            }
            else
            {
                var getUser = _db.Users.FirstOrDefault(x=>x.UserName == user);
                var giohang = _db.GioHangs.FirstOrDefault(x => x.UserID == getUser.Id);
                var ghctData = _db.GHHCTs.Where(x=>x.CartId == giohang.Id).ToList();
                return View(ghctData);
            }
        }
    }
}
