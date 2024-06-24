using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init36 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Instructors_InstructorId",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "Records",
                newName: "CourseGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_CourseGroups_CourseGroupId",
                table: "Records",
                column: "CourseGroupId",
                principalTable: "CourseGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_CourseGroups_CourseGroupId",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "CourseGroupId",
                table: "Records",
                newName: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Instructors_InstructorId",
                table: "Records",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
