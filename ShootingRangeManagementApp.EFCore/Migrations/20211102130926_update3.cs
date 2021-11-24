using Microsoft.EntityFrameworkCore.Migrations;

namespace ShootingRangeManagementApp.EFCore.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "DailyStoreGiros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "DailyStoreGiros",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
