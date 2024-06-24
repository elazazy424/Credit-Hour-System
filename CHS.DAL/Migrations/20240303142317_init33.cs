using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teaches");

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_InstructorId",
                table: "Lectures",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Instructors_InstructorId",
                table: "Lectures",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Instructors_InstructorId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_InstructorId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Lectures");

            migrationBuilder.CreateTable(
                name: "Teaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseGroupId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teaches_CourseGroups_CourseGroupId",
                        column: x => x.CourseGroupId,
                        principalTable: "CourseGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teaches_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_CourseGroupId",
                table: "Teaches",
                column: "CourseGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_InstructorId",
                table: "Teaches",
                column: "InstructorId");
        }
    }
}
