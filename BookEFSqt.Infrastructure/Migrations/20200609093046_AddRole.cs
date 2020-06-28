using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Book.Core.EntityFramWork.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LinkUrl = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    OrderSort = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsMenu = table.Column<bool>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    CreateId = table.Column<int>(nullable: true),
                    CreateBy = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyId = table.Column<int>(nullable: true),
                    ModifyBy = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsButton = table.Column<bool>(nullable: false),
                    IsHide = table.Column<bool>(nullable: true),
                    IskeepAlive = table.Column<bool>(nullable: true),
                    Func = table.Column<string>(nullable: true),
                    Pid = table.Column<int>(nullable: false),
                    Mid = table.Column<int>(nullable: false),
                    OrderSort = table.Column<int>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    CreateId = table.Column<int>(nullable: true),
                    CreateBy = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    ModifyId = table.Column<int>(nullable: true),
                    ModifyBy = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OrderSort = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    CreateId = table.Column<int>(nullable: true),
                    CreateBy = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    ModifyId = table.Column<int>(nullable: true),
                    ModifyBy = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sysUserInfo",
                columns: table => new
                {
                    uID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uLoginName = table.Column<string>(nullable: true),
                    uLoginPWD = table.Column<string>(nullable: true),
                    uRealName = table.Column<string>(nullable: true),
                    uStatus = table.Column<int>(nullable: false),
                    uRemark = table.Column<string>(nullable: true),
                    uCreateTime = table.Column<DateTime>(nullable: false),
                    uUpdateTime = table.Column<DateTime>(nullable: false),
                    uLastErrTime = table.Column<DateTime>(nullable: false),
                    uErrorCount = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    sex = table.Column<int>(nullable: false),
                    age = table.Column<int>(nullable: false),
                    birth = table.Column<DateTime>(nullable: false),
                    addr = table.Column<string>(nullable: true),
                    tdIsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sysUserInfo", x => x.uID);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreateId = table.Column<int>(nullable: true),
                    CreateBy = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    ModifyId = table.Column<int>(nullable: true),
                    ModifyBy = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleModulePermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: true),
                    CreateId = table.Column<int>(nullable: true),
                    CreateBy = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    ModifyId = table.Column<int>(nullable: true),
                    ModifyBy = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModulePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleModulePermission_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleModulePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleModulePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleModulePermission_ModuleId",
                table: "RoleModulePermission",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModulePermission_PermissionId",
                table: "RoleModulePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModulePermission_RoleId",
                table: "RoleModulePermission",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleModulePermission");

            migrationBuilder.DropTable(
                name: "sysUserInfo");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
