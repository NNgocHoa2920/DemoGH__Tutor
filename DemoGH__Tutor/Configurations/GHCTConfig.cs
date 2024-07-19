using DemoGH__Tutor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoGH__Tutor.Configurations
{
    public class GHCTConfig : IEntityTypeConfiguration<GHHCT>
    {
        public void Configure(EntityTypeBuilder<GHHCT> builder)
        {
            //TẠO KHÓA CHÍNH
            builder.HasKey(x => x.Id);
            //tạo mối quan hệ 1-n
            //hasone: chỉ mối quan hệ 1
            //WithMany chỉ ra bảng  nhiều
            //builder.HasOne(x => x.GioHang).WithMany(x => x.GHHCT)
            //    .HasForeignKey(x => x.CartId);
            
            //1 giỏ hàng thì có nhiều giỏ hàng chi tiết và có cartId là khóa ngoại
            //builder.HasOne(x => x.SanPham).WithMany(x => x.GHHCT)
            //    .HasForeignKey(x => x.ProductID);
            builder.HasOne<GioHang>(x=>x.GioHang).WithMany(x=>x.GHHCT)
                .HasForeignKey(x=>x.CartId);
            builder.HasOne<SanPham>(x => x.SanPham).WithMany(x => x.GHHCT)
               .HasForeignKey(x => x.ProductID);
        }
    }
}
