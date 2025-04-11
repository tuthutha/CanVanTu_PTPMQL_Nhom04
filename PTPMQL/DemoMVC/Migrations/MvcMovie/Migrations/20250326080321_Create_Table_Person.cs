using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMVC.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeThongPhanPhois",
                columns: table => new
                {
                    MaHTPP = table.Column<string>(type: "TEXT", nullable: false),
                    TenHTPP = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeThongPhanPhois", x => x.MaHTPP);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    EmployeeId = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "DaiLys",
                columns: table => new
                {
                    MaDaiLy = table.Column<string>(type: "TEXT", nullable: false),
                    TenDaiLy = table.Column<string>(type: "TEXT", nullable: true),
                    DiaChi = table.Column<string>(type: "TEXT", nullable: true),
                    NguoiDaiDien = table.Column<string>(type: "TEXT", nullable: true),
                    DienThoai = table.Column<string>(type: "TEXT", nullable: true),
                    MaHTPP = table.Column<string>(type: "TEXT", nullable: true),
                    HeThongPhanPhoiMaHTPP = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaiLys", x => x.MaDaiLy);
                    table.ForeignKey(
                        name: "FK_DaiLys_HeThongPhanPhois_HeThongPhanPhoiMaHTPP",
                        column: x => x.HeThongPhanPhoiMaHTPP,
                        principalTable: "HeThongPhanPhois",
                        principalColumn: "MaHTPP");
                    table.ForeignKey(
                        name: "FK_DaiLys_HeThongPhanPhois_MaHTPP",
                        column: x => x.MaHTPP,
                        principalTable: "HeThongPhanPhois",
                        principalColumn: "MaHTPP");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaiLys_HeThongPhanPhoiMaHTPP",
                table: "DaiLys",
                column: "HeThongPhanPhoiMaHTPP");

            migrationBuilder.CreateIndex(
                name: "IX_DaiLys_MaHTPP",
                table: "DaiLys",
                column: "MaHTPP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaiLys");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "HeThongPhanPhois");
        }
    }
}