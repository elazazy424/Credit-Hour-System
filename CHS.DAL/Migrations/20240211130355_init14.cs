using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Instructors_InstructorIdFk",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Lectures_LectureIdFk",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Students_StudentIdFk",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_InstructorIdFk",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_LectureIdFk",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_StudentIdFk",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "InstructorIdFk",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "LectureIdFk",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "StudentIdFk",
                table: "Records");

            migrationBuilder.CreateIndex(
                name: "IX_Records_LectureId",
                table: "Records",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_StudentId",
                table: "Records",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Instructors_InstructorId",
                table: "Records",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Lectures_LectureId",
                table: "Records",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Students_StudentId",
                table: "Records",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Instructors_InstructorId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Lectures_LectureId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Students_StudentId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_LectureId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_StudentId",
                table: "Records");

            migrationBuilder.AddColumn<int>(
                name: "InstructorIdFk",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LectureIdFk",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentIdFk",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Instructors_InstructorIdFk",
                table: "Records",
                column: "InstructorIdFk",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Lectures_LectureIdFk",
                table: "Records",
                column: "LectureIdFk",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Students_StudentIdFk",
                table: "Records",
                column: "StudentIdFk",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
