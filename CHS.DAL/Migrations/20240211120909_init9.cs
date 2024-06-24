using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    SemesterTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SemesterTitleFk = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTables_Semesters_SemesterTitleFk",
                        column: x => x.SemesterTitleFk,
                        principalTable: "Semesters",
                        principalColumn: "SemesterTitle");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_SemesterTitleFk",
                table: "TimeTables",
                column: "SemesterTitleFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeTables");
        }
    }
}
