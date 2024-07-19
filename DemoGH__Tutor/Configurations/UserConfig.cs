using DemoGH__Tutor.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace DemoGH__Tutor.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            //config cho các thuộc tính
            builder.Property(x => x.Password)
                .HasColumnName("MatKhau")
                .HasColumnType("varchar(256)");
            //nvarchar(256)
            builder.Property(x => x.Name)
                .IsUnicode(true)
                .IsFixedLength(true)
                .HasMaxLength(256);

            //cấu hình mqh 1-1 vs giỏ hàng
            builder.HasOne(x => x.GioHang)
                .WithOne(x => x.User)
                .HasForeignKey<GioHang>(x => x.UserID); 

            
        }
    }
}
