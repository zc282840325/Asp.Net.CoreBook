using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Book.Core.EntityFramWork.Migrations
{
    public partial class ADDFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "sysUserInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Borroweds",
                table: "sysUserInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Borrows",
                table: "sysUserInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IDNumber",
                table: "sysUserInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsReportLoss",
                table: "sysUserInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "sysUserInfo",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UnpaidFine",
                table: "sysUserInfo",
                nullable: false,
                defaultValue: 0.0);



            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "Role",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowNumbers = table.Column<int>(nullable: false),
                    BorrowDays = table.Column<int>(nullable: false),
                    RenewDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "sysUserInfo");

            migrationBuilder.DropColumn(
                name: "Borroweds",
                table: "sysUserInfo");

            migrationBuilder.DropColumn(
                name: "Borrows",
                table: "sysUserInfo");

            migrationBuilder.DropColumn(
                name: "IDNumber",
                table: "sysUserInfo");

            migrationBuilder.DropColumn(
                name: "IsReportLoss",
                table: "sysUserInfo");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "sysUserInfo");

            migrationBuilder.DropColumn(
                name: "UnpaidFine",
                table: "sysUserInfo");

    

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Role");
        }
    }
}
