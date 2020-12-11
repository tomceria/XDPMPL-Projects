using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechShop_Web.Migrations
{
    public partial class TodoTaskCompleteDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompleteDate",
                table: "TodoTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompleteDate",
                table: "TodoTasks");
        }
    }
}
