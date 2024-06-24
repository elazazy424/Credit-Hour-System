using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluates",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    WorksGrade = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    MidtermGrade = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    ProjectGrade = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    FinalGrade = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    TotalGrade = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluates", x => new { x.StudentId, x.CourseId, x.InstructorId });
                    table.ForeignKey(
                        name: "FK_Evaluates_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluates_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluates_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluates_CourseId",
                table: "Evaluates",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluates_InstructorId",
                table: "Evaluates",
                column: "InstructorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluates");
        }
    }
}
