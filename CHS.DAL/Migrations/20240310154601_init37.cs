using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init37 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Lectures_LectureId",
                table: "Records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Records",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_LectureId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Records");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Records",
                table: "Records",
                columns: new[] { "CourseGroupId", "StudentId", "Week" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Records",
                table: "Records");

            migrationBuilder.AddColumn<int>(
                name: "LectureId",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Records",
                table: "Records",
                columns: new[] { "CourseGroupId", "StudentId", "LectureId", "Week" });

            migrationBuilder.CreateIndex(
                name: "IX_Records_LectureId",
                table: "Records",
                column: "LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Lectures_LectureId",
                table: "Records",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
