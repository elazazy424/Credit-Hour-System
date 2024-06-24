using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init40 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "studentTrackers",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SemesterTitle = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    GPA = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    MaximumHours = table.Column<int>(type: "int", nullable: false),
                    RecordedHours = table.Column<int>(type: "int", nullable: false),
                    Tracker = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentTrackers", x => new { x.StudentId, x.SemesterTitle });
                    table.ForeignKey(
                        name: "FK_studentTrackers_Semesters_SemesterTitle",
                        column: x => x.SemesterTitle,
                        principalTable: "Semesters",
                        principalColumn: "SemesterTitle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentTrackers_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentTrackers_SemesterTitle",
                table: "studentTrackers",
                column: "SemesterTitle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentTrackers");
        }
    }
}
