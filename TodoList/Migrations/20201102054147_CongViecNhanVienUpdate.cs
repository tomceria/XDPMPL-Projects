using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class CongViecNhanVienUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Privacy",
                table: "DSCongViec");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "DSCongViec");

            migrationBuilder.AddColumn<int>(
                name: "Access",
                table: "DSCongViec",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "DSCongViec",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Access",
                table: "DSCongViec");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DSCongViec");

            migrationBuilder.AddColumn<int>(
                name: "Privacy",
                table: "DSCongViec",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "DSCongViec",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
