using DemoGH__Tutor.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//các cháu nhớ add ở chỗ này - 
//copy servie thì nhớ sửa tên class dbcontext
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//khai báo dịch vụ cho thằng session
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromSeconds(30);
    //khai báo thời gian để seesion timeout
    //có nghĩa là nếu người dùng k thực hiện yêu cầu nào trong vòng 15s thì session của họ sẽ bị hết hạn
    //nếu có thì bộ đếm sẽ reset lại, dữ liệu được lưu webserver
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//sử dụng seesion --khai báo ở đâY

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//loocal.../ controller/ actionn
//ví dụ: cô muốn điều hướng sang trang tạo mới sản phẩm]
// xác định cho cô: conller:SanPham   action:  Create
// local.../sanpham/create

app.Run();
