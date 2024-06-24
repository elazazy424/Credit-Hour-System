using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init42 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluates_Courses_CourseId",
                table: "Evaluates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evaluates",
                table: "Evaluates");

            migrationBuilder.DropIndex(
                name: "IX_Evaluates_CourseId",
                table: "Evaluates");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Evaluates");

            migrationBuilder.AddColumn<int>(
                name: "CourseGroupId",
                table: "Evaluates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evaluates",
                table: "Evaluates",
                columns: new[] { "StudentId", "CourseGroupId", "InstructorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluates_CourseGroupId",
                table: "Evaluates",
                column: "CourseGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluates_CourseGroups_CourseGroupId",
                table: "Evaluates",
                column: "CourseGroupId",
                principalTable: "CourseGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluates_CourseGroups_CourseGroupId",
                table: "Evaluates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evaluates",
                table: "Evaluates");

            migrationBuilder.DropIndex(
                name: "IX_Evaluates_CourseGroupId",
                table: "Evaluates");

            migrationBuilder.DropColumn(
                name: "CourseGroupId",
                table: "Evaluates");

            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "Evaluates",
                type: "nvarchar(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evaluates",
                table: "Evaluates",
                columns: new[] { "StudentId", "CourseId", "InstructorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluates_CourseId",
                table: "Evaluates",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluates_Courses_CourseId",
                table: "Evaluates",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
