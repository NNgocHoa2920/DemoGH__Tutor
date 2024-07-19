using Microsoft.EntityFrameworkCore;

namespace DemoGH__Tutor.Models
{
    public class AppDbContext : DbContext
    {
        ////public AppDbContext()
        ////{

        //}
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //tạo các dbset - đại diện cho 1 bảng ơpr csdl
        //có nghĩa là khi thêm sửa xóa thì dùng dbset chứ k phải models
        public DbSet<User> Users { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GHHCT> GHHCTs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-DII2Q16\\SQLEXPRESS;Database=GHDM;Trusted_Connection=True;TrustServerCertificate=True");
        //}

    }
}
