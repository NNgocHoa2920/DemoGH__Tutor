using DemoGH__Tutor.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            //lấy giá trị sesion có tên là username
            var seesionData = HttpContext.Session.GetString("username"); // vì mình set lưu trữ vào key là username
            if (seesionData == null) // check chhwa đăng nhập
            {
                //ViewData["message"] = "Chưa đăng nhập bạn ê";
                return Content ("Chhwa đăng nhập chưa xem được má");
            }
            else // đăng nhập rồi
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

        //đăng kí
        public IActionResult Dangky() // Tạo ra 1 form đăng kí
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(User user)
        {
            try
            {
                ///tạo mới 1 user
                _db.Users.Add(user);
                //khi tạo user đồng thời sẽ tạo ra 1 giỏ hàng
                GioHang gioHang = new GioHang()
                {
                    UserName = user.Name,
                };
                _db.GioHangs.Add(gioHang);
                _db.SaveChanges();
                TempData["Status"] = "Chúc mừng bạn đã tạo tài khoản thành công";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
           
        }

        //Đăng nhập
        public IActionResult Login()
        {
            return View(); 

        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            //check xem username và pass có nhập hay k
            if (username == null|| password==null )
            {
                return View();  // nếu k nhập tk hoặc mk thì view vẫn giữ nguyên là view loigin
            } 
            
            //Tìm kiếm xem là user và pass của mình nhập có tồn tại trỏng csdl hay k
            var acc = _db.Users.ToList().FirstOrDefault(x=>x.UserName == username && x.Password==password);
            if (acc == null) // nếu k tìm thấu tài khoản trong csdl
            {
                return Content("Đăng nhập không thành công mời kiểm tta lại tài khoản");
            }
            else
            {
                HttpContext.Session.SetString("username", username); // lưu dữ liệu login vào sessionm với key là username
                return RedirectToAction("Index", "Home");
            }
                
        }

        //thêm mới 1 acc
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                ///tạo mới 1 user
                _db.Users.Add(user);
                //khi tạo user đồng thời sẽ tạo ra 1 giỏ hàng
                GioHang gioHang = new GioHang()
                {
                    UserName = user.Name,
                };
                _db.GioHangs.Add(gioHang);
                _db.SaveChanges();
                TempData["Status"] = "Chúc mừng bạn đã tạo tài khoản thành công";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet] // nếu k nói gì thì mặc định là htttp get
        public IActionResult Delete(Guid id)
        {
            //lấy ra đối tượng mà muốn xóa
            var deleteUser = _db.Users.Find(id);
            
            //khi các bạn muốn làm roll back hoặc xem lại giữ liệu đã xóa thì các bạn mới làm đoạn này
            //ép kiểu sang Json để tí nữa xem lại dữ liệu đã xóa và muốn hiển thị ở dạng JSON
            var jsonData = JsonConvert.SerializeObject(deleteUser);
            HttpContext.Session.SetString("deleted", jsonData);// luu giữ lựu đã xóa vào sesion

            //xong khi lưu tạm thời vào session thì mới xóa

            _db.Remove(deleteUser);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //xem lại dữ liệu đã xóa
        public IActionResult RetrieveDeleteData()
        {
            var jsonData = HttpContext.Session.GetString("deleted"); // lấy dữ liệu đã lưu
            if(jsonData != null)
            {
                var deleteUser = JsonConvert.DeserializeObject<User>(jsonData);
                return View("DeletedUserDetails", deleteUser);
            }
            else
            {
                // Xử lý khi không tìm thấy dữ liệu trong session
                return RedirectToAction("Index");
            }
        }

        //KHÔI PHỤC LẠI DỮ LIỆU ĐÃ XÓA/ HOẶC SỬA ( LÀM TƯƠNG TỰ)
        public IActionResult RollBack()
        {
            //check xem dữ lieeju đã xóa đã đc lưu vào session hay chưa
            if (HttpContext.Session.Keys.Contains("deleted"))
            {
                //lấy giữ lựu đã lưu vào session ra
                var jSonData = HttpContext.Session.GetString("deleted");

                //tạo 1 đối tượng có dữ liệu y hệt dữ liệu cũ
                var deletedUsser = JsonConvert.DeserializeObject<User>(jSonData);
                _db.Users.Add(deletedUsser);  //add lại vào trong db
                _db.SaveChanges();
                return RedirectToAction("Index");


            }
            else
            {
                return Content("chưa lưu vào session được xóa");
            }
             
        }




    }
}
