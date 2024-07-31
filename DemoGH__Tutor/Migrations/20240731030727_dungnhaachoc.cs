using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoGH__Tutor.Migrations
{
    public partial class dungnhaachoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GHHCTs_GioHangs_GioHangId",
                table: "GHHCTs");

            migrationBuilder.DropForeignKey(
                name: "FK_GHHCTs_SanPhams_SanPhamId",
                table: "GHHCTs");

            migrationBuilder.AlterColumn<Guid>(
                name: "SanPhamId",
                table: "GHHCTs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductID",
                table: "GHHCTs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GioHangId",
                table: "GHHCTs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "GHHCTs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_GHHCTs_GioHangs_GioHangId",
                table: "GHHCTs",
                column: "GioHangId",
                principalTable: "GioHangs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GHHCTs_SanPhams_SanPhamId",
                table: "GHHCTs",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "SanPhamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GHHCTs_GioHangs_GioHangId",
                table: "GHHCTs");

            migrationBuilder.DropForeignKey(
                name: "FK_GHHCTs_SanPhams_SanPhamId",
                table: "GHHCTs");

            migrationBuilder.AlterColumn<Guid>(
                name: "SanPhamId",
                table: "GHHCTs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductID",
                table: "GHHCTs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GioHangId",
                table: "GHHCTs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "GHHCTs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GHHCTs_GioHangs_GioHangId",
                table: "GHHCTs",
                column: "GioHangId",
                principalTable: "GioHangs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GHHCTs_SanPhams_SanPhamId",
                table: "GHHCTs",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "SanPhamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
