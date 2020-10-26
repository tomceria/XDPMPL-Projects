using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DSNhanVien",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSNhanVien", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DSCongViec",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    TrangThai = table.Column<int>(nullable: false),
                    Privacy = table.Column<int>(nullable: false),
                    NhanVienID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSCongViec", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DSCongViec_DSNhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "DSNhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DSBinhLuan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(nullable: true),
                    CongViecID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSBinhLuan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DSBinhLuan_DSCongViec_CongViecID",
                        column: x => x.CongViecID,
                        principalTable: "DSCongViec",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DSNguoiLamChung",
                columns: table => new
                {
                    NguoiLamChungID = table.Column<int>(nullable: false),
                    CongViecID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSNguoiLamChung", x => x.NguoiLamChungID);
                    table.ForeignKey(
                        name: "FK_DSNguoiLamChung_DSCongViec_CongViecID",
                        column: x => x.CongViecID,
                        principalTable: "DSCongViec",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DSNguoiLamChung_DSNhanVien_NguoiLamChungID",
                        column: x => x.NguoiLamChungID,
                        principalTable: "DSNhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DSBinhLuan_CongViecID",
                table: "DSBinhLuan",
                column: "CongViecID");

            migrationBuilder.CreateIndex(
                name: "IX_DSCongViec_NhanVienID",
                table: "DSCongViec",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_DSNguoiLamChung_CongViecID",
                table: "DSNguoiLamChung",
                column: "CongViecID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DSBinhLuan");

            migrationBuilder.DropTable(
                name: "DSNguoiLamChung");

            migrationBuilder.DropTable(
                name: "DSCongViec");

            migrationBuilder.DropTable(
                name: "DSNhanVien");
        }
    }
}
