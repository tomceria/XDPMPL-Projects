using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class StaffCreatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "TodoTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TodoTasks_CreatedById",
                table: "TodoTasks",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_Staffs_CreatedById",
                table: "TodoTasks",
                column: "CreatedById",
                principalTable: "Staffs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_Staffs_CreatedById",
                table: "TodoTasks");

            migrationBuilder.DropIndex(
                name: "IX_TodoTasks_CreatedById",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "TodoTasks");
        }
    }
}
