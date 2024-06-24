using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_Courses_CourseCode",
                table: "Enrolls");

            migrationBuilder.DropIndex(
                name: "IX_Enrolls_CourseCode",
                table: "Enrolls");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "Enrolls");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "Enrolls",
                type: "nvarchar(5)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrolls_CourseCode",
                table: "Enrolls",
                column: "CourseCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_Courses_CourseCode",
                table: "Enrolls",
                column: "CourseCode",
                principalTable: "Courses",
                principalColumn: "CourseCode");
        }
    }
}
