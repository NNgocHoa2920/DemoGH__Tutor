using DemoGH__Tutor.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoGH__Tutor.Controllers
{
    public class SanPhamController : Controller
    {
        // dùng đến csdl => mình crud => đụng đến class appdbContext
        AppDbContext _db; // biến toàn cục thường sẽ đến dấu _ 
        public SanPhamController(AppDbContext db)
        {
            _db = db;
        }
        //lấy ra toàn bộ dữ liệu của bảng sản phẩmn
        [HttpGet]
        public IActionResult Index()
        {
            var spData = _db.SanPhams.ToList();
            return View(spData);
        }
        //tạo 1 sản phẩm
        public IActionResult Create() // dùng để tạo ra trang create
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SanPham sanPham)
        {
            _db.SanPhams.Add(sanPham);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //sửa 1 sp
        public IActionResult Edit(Guid id)
        {
            var spEdit = _db.SanPhams.Find(id); // lấy ra đối tượng cần sửa
            return View(spEdit);
        }
        [HttpPost]
        public IActionResult Edit(SanPham sanPham)
        {
           _db.SanPhams.Update(sanPham);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

       // tHÊM VÀO GIỎ HÀNG, XỬ LÍ CỘNG DỒN
        public IActionResult AddToCard(Guid id, int soLuong) // id là id của sp add
        {
            //lấy ra username tương ứng với giỏ hàng

            var user = HttpContext.Session.GetString("username");
            if (user == null)
            {
                return Content("Chưa đăng nhập hoặc hết hạn");
            }
            //lấy thông tin của user=> lấy toàn bộ đối tượng
            var getUser = _db.Users.FirstOrDefault(x => x.UserName == user); // getUsser là 1 đối tượng
            //lấy giỏ hàn tương ứng
            var gioHang = _db.GioHangs.FirstOrDefault(x => x.UserID == getUser.Id);
            if (gioHang == null)
            {
                return Content("Chưa có giỏ hànng");
            }

            //lấy toàn bộ sản phẩm trong giỏ giỏ hàng chi tiết của user
            var userCart = _db.GHHCTs.Where(x => x.CartId == gioHang.Id).ToList();

            //duyệt ghct
            bool checkGH = false;
            Guid idGHCT = Guid.NewGuid();

            foreach (var item in userCart)
            {
                if(item.ProductID == id)
                {
                    //nếu id sp trong gio hang cuỷa user trùng với cái được chọn
                    checkGH = true;
                    idGHCT = item.Id; // lấy ra id cuỷa ghct để tí nữa mình update
                    break;
                }
            }

            //nếu sp chưa được chọn
            if (!checkGH)
            {
                //tạo ra ghct ứng với sp đóp
                GHHCT ghct = new GHHCT()
                {
                    ProductID = id,
                    CartId = gioHang.Id,
                    SoLuong = soLuong,

                };
                _db.GHHCTs.Add(ghct);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //nếu sp đc chọn rồi
            else
            {
                var ghctUpdate = _db.GHHCTs.FirstOrDefault(x => x.Id == idGHCT); // tìm theo ghct
                ghctUpdate.SoLuong = ghctUpdate.SoLuong + soLuong;
                _db.GHHCTs.Update(ghctUpdate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }


        }
    }
}
