using DemoGH__Tutor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoGH__Tutor.Configurations
{
    public class CartConfig : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.HasKey(x => x.Id);

            //cấu hình mqh 1-1 với user
            builder.HasOne(x => x.User).WithOne(x => x.GioHang)
                .HasForeignKey<GioHang>(x => x.UserID); //THÊM THUỘC TÍNH 1-1
                
        }
    }
}
