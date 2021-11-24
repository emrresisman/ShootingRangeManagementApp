using Microsoft.EntityFrameworkCore.Migrations;

namespace ShootingRangeManagementApp.EFCore.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmountDaily",
                table: "DailyStoreGiros",
                newName: "CreditCart");

            migrationBuilder.AddColumn<int>(
                name: "Cash",
                table: "DailyStoreGiros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cash",
                table: "DailyStoreGiros");

            migrationBuilder.RenameColumn(
                name: "CreditCart",
                table: "DailyStoreGiros",
                newName: "TotalAmountDaily");
        }
    }
}
