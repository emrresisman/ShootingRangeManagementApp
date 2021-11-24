using Microsoft.EntityFrameworkCore.Migrations;

namespace ShootingRangeManagementApp.EFCore.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Bills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
