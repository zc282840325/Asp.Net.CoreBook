using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Book.Core.EntityFramWork.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Book");

            migrationBuilder.DropTable(
                name: "tb_BookDamaged");

            migrationBuilder.DropTable(
                name: "tb_BookDamagedDetails");

            migrationBuilder.DropTable(
                name: "tb_BookStorage");

            migrationBuilder.DropTable(
                name: "tb_BookStorageDetails");

            migrationBuilder.DropTable(
                name: "tb_BookType");

            migrationBuilder.DropTable(
                name: "tb_Borrow");

            migrationBuilder.DropTable(
                name: "tb_FineBill");

            migrationBuilder.DropTable(
                name: "tb_Library");

            migrationBuilder.DropTable(
                name: "tb_PublishingHouse");

            migrationBuilder.DropTable(
                name: "tb_Reader");

            migrationBuilder.DropTable(
                name: "tb_ReaderType");

            migrationBuilder.DropTable(
                name: "tb_Staff");
        }
    }
}
