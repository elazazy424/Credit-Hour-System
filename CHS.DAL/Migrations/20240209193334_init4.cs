using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enroll_Courses_CourseId",
                table: "Enroll");

            migrationBuilder.DropForeignKey(
                name: "FK_Enroll_Students_StudentId",
                table: "Enroll");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enroll",
                table: "Enroll");

            migrationBuilder.RenameTable(
                name: "Enroll",
                newName: "Enrolls");

            migrationBuilder.RenameIndex(
                name: "IX_Enroll_CourseId",
                table: "Enrolls",
                newName: "IX_Enrolls_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrolls",
                table: "Enrolls",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_Courses_CourseId",
                table: "Enrolls",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_Students_StudentId",
                table: "Enrolls",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_Courses_CourseId",
                table: "Enrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_Students_StudentId",
                table: "Enrolls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrolls",
                table: "Enrolls");

            migrationBuilder.RenameTable(
                name: "Enrolls",
                newName: "Enroll");

            migrationBuilder.RenameIndex(
                name: "IX_Enrolls_CourseId",
                table: "Enroll",
                newName: "IX_Enroll_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enroll",
                table: "Enroll",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Enroll_Courses_CourseId",
                table: "Enroll",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enroll_Students_StudentId",
                table: "Enroll",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
