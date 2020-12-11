using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechShop_Web.Migrations
{
    public partial class CommentCreatedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                nullable: false,
                defaultValue: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Comments");
        }
    }
}
