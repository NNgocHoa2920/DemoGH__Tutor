using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoGH__Tutor.Migrations
{
    public partial class dungnhaachochhhhhh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "GHHCTs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "GHHCTs");
        }
    }
}
