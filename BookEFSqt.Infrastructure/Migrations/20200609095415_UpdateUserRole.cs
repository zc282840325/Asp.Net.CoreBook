using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Book.Core.EntityFramWork.Migrations
{
    public partial class UpdateUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "addr",
                table: "sysUserInfo");

            migrationBuilder.DropColumn(
                name: "age",
                table: "sysUserInfo");

            migrationBuilder.DropColumn(
                name: "birth",
                table: "sysUserInfo");

            migrationBuilder.DropColumn(
                name: "name",
                table: "sysUserInfo");

            migrationBuilder.DropColumn(
                name: "sex",
                table: "sysUserInfo");

            migrationBuilder.DropColumn(
                name: "tdIsDelete",
                table: "sysUserInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "addr",
                table: "sysUserInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "sysUserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "birth",
                table: "sysUserInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "sysUserInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "sex",
                table: "sysUserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "tdIsDelete",
                table: "sysUserInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
