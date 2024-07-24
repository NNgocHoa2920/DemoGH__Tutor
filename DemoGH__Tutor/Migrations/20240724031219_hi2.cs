using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoGH__Tutor.Migrations
{
    public partial class hi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GioHangs_Users_UserID",
                table: "GioHangs");

            migrationBuilder.DropIndex(
                name: "IX_GioHangs_UserID",
                table: "GioHangs");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "GioHangs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_UserID",
                table: "GioHangs",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_GioHangs_Users_UserID",
                table: "GioHangs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GioHangs_Users_UserID",
                table: "GioHangs");

            migrationBuilder.DropIndex(
                name: "IX_GioHangs_UserID",
                table: "GioHangs");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "GioHangs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_UserID",
                table: "GioHangs",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GioHangs_Users_UserID",
                table: "GioHangs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
