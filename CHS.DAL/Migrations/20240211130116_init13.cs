using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    LectureId = table.Column<int>(type: "int", nullable: false),
                    Week = table.Column<int>(type: "int", nullable: false),
                    InstructorIdFk = table.Column<int>(type: "int", nullable: false),
                    StudentIdFk = table.Column<int>(type: "int", nullable: false),
                    LectureIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => new { x.InstructorId, x.StudentId, x.LectureId });
                    table.ForeignKey(
                        name: "FK_Records_Instructors_InstructorIdFk",
                        column: x => x.InstructorIdFk,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Lectures_LectureIdFk",
                        column: x => x.LectureIdFk,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Students_StudentIdFk",
                        column: x => x.StudentIdFk,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_InstructorIdFk",
                table: "Records",
                column: "InstructorIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Records_LectureIdFk",
                table: "Records",
                column: "LectureIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Records_StudentIdFk",
                table: "Records",
                column: "StudentIdFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");
        }
    }
}
