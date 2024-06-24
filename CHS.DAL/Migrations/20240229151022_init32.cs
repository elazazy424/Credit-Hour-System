using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teaches",
                table: "Teaches");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Teaches",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teaches",
                table: "Teaches",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_InstructorId",
                table: "Teaches",
                column: "InstructorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teaches",
                table: "Teaches");

            migrationBuilder.DropIndex(
                name: "IX_Teaches_InstructorId",
                table: "Teaches");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Teaches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teaches",
                table: "Teaches",
                columns: new[] { "InstructorId", "CourseGroupId" });
        }
    }
}
