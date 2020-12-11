using Microsoft.EntityFrameworkCore.Migrations;

namespace TechShop_Web.Migrations
{
    public partial class StaffUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTaskPartners_TodoTasks_TodoTaskId",
                table: "TodoTaskPartners");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Staffs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TodoTasks",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTaskPartners_TodoTasks_TodoTaskId",
                table: "TodoTaskPartners",
                column: "TodoTaskId",
                principalTable: "TodoTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTaskPartners_TodoTasks_TodoTaskId",
                table: "TodoTaskPartners");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Staffs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TodoTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTaskPartners_TodoTasks_TodoTaskId",
                table: "TodoTaskPartners",
                column: "TodoTaskId",
                principalTable: "TodoTasks",
                principalColumn: "Id");
        }
    }
}
