using Microsoft.EntityFrameworkCore.Migrations;

namespace TechShopWeb.Migrations
{
    public partial class IsHiddens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Combos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Combos");
        }
    }
}
