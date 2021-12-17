using Microsoft.EntityFrameworkCore.Migrations;

namespace ShootingRangeManagementApp.EFCore.Migrations
{
    public partial class keyupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserStore",
                table: "AppUserStore");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AppUserStore",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserStore",
                table: "AppUserStore",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserStore_AppUserId",
                table: "AppUserStore",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserStore",
                table: "AppUserStore");

            migrationBuilder.DropIndex(
                name: "IX_AppUserStore_AppUserId",
                table: "AppUserStore");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AppUserStore");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserStore",
                table: "AppUserStore",
                columns: new[] { "AppUserId", "StoreId" });
        }
    }
}
