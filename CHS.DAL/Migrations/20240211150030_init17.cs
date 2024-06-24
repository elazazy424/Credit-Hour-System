using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseHasSemesters",
                columns: table => new
                {
                    SemsterTitle = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    NumberOfStudentsEnrolled = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseHasSemesters", x => new { x.SemsterTitle, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CourseHasSemesters_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseHasSemesters_Semesters_SemsterTitle",
                        column: x => x.SemsterTitle,
                        principalTable: "Semesters",
                        principalColumn: "SemesterTitle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseHasSemesters_CourseId",
                table: "CourseHasSemesters",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseHasSemesters");
        }
    }
}
