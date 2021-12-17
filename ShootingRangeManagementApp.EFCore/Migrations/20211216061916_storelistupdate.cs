using Microsoft.EntityFrameworkCore.Migrations;

namespace ShootingRangeManagementApp.EFCore.Migrations
{
    public partial class storelistupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserStore_Stores_StoresStoreId",
                table: "AppUserStore");

            migrationBuilder.DropIndex(
                name: "IX_AppUserStore_StoresStoreId",
                table: "AppUserStore");

            migrationBuilder.RenameColumn(
                name: "StoresStoreId",
                table: "AppUserStore",
                newName: "StoreId");

            migrationBuilder.AddColumn<int>(
                name: "StoreId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StoreId1",
                table: "AspNetUsers",
                column: "StoreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stores_StoreId1",
                table: "AspNetUsers",
                column: "StoreId1",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stores_StoreId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StoreId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StoreId1",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "AppUserStore",
                newName: "StoresStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserStore_StoresStoreId",
                table: "AppUserStore",
                column: "StoresStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserStore_Stores_StoresStoreId",
                table: "AppUserStore",
                column: "StoresStoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
