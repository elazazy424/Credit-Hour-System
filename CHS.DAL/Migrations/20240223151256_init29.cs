using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_Courses_CourseId",
                table: "Enrolls");



            migrationBuilder.DropForeignKey(
                name: "FK_Teaches_Courses_CourseId",
                table: "Teaches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teaches",
                table: "Teaches");

            migrationBuilder.DropIndex(
                name: "IX_Teaches_CourseId",
                table: "Teaches");



            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrolls",
                table: "Enrolls");

            migrationBuilder.DropIndex(
                name: "IX_Enrolls_CourseId",
                table: "Enrolls");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Teaches");



            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Enrolls");

            migrationBuilder.DropColumn(
                name: "group",
                table: "Enrolls");

            migrationBuilder.AddColumn<int>(
                name: "CourseGroupId",
                table: "Teaches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseGroupId",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseGroupId",
                table: "Enrolls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "Enrolls",
                type: "nvarchar(5)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teaches",
                table: "Teaches",
                columns: new[] { "InstructorId", "CourseGroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrolls",
                table: "Enrolls",
                columns: new[] { "StudentId", "CourseGroupId" });

            migrationBuilder.CreateTable(
                name: "CourseGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    SemesterTitle = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CurrentCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseGroup_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseGroup_Semesters_SemesterTitle",
                        column: x => x.SemesterTitle,
                        principalTable: "Semesters",
                        principalColumn: "SemesterTitle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_CourseGroupId",
                table: "Teaches",
                column: "CourseGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseGroupId",
                table: "Lectures",
                column: "CourseGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolls_CourseCode",
                table: "Enrolls",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolls_CourseGroupId",
                table: "Enrolls",
                column: "CourseGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroup_CourseCode",
                table: "CourseGroup",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroup_SemesterTitle",
                table: "CourseGroup",
                column: "SemesterTitle");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_CourseGroup_CourseGroupId",
                table: "Enrolls",
                column: "CourseGroupId",
                principalTable: "CourseGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_Courses_CourseCode",
                table: "Enrolls",
                column: "CourseCode",
                principalTable: "Courses",
                principalColumn: "CourseCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_CourseGroup_CourseGroupId",
                table: "Lectures",
                column: "CourseGroupId",
                principalTable: "CourseGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Teaches_CourseGroup_CourseGroupId",
                table: "Teaches",
                column: "CourseGroupId",
                principalTable: "CourseGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_CourseGroup_CourseGroupId",
                table: "Enrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_Courses_CourseCode",
                table: "Enrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_CourseGroup_CourseGroupId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Teaches_CourseGroup_CourseGroupId",
                table: "Teaches");

            migrationBuilder.DropTable(
                name: "CourseGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teaches",
                table: "Teaches");

            migrationBuilder.DropIndex(
                name: "IX_Teaches_CourseGroupId",
                table: "Teaches");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_CourseGroupId",
                table: "Lectures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrolls",
                table: "Enrolls");

            migrationBuilder.DropIndex(
                name: "IX_Enrolls_CourseCode",
                table: "Enrolls");

            migrationBuilder.DropIndex(
                name: "IX_Enrolls_CourseGroupId",
                table: "Enrolls");

            migrationBuilder.DropColumn(
                name: "CourseGroupId",
                table: "Teaches");

            migrationBuilder.DropColumn(
                name: "CourseGroupId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "CourseGroupId",
                table: "Enrolls");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "Enrolls");

            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "Teaches",
                type: "nvarchar(5)",
                nullable: false,
                defaultValue: "");

           

            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "Enrolls",
                type: "nvarchar(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "group",
                table: "Enrolls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teaches",
                table: "Teaches",
                columns: new[] { "InstructorId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrolls",
                table: "Enrolls",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_CourseId",
                table: "Teaches",
                column: "CourseId");

          

            migrationBuilder.CreateIndex(
                name: "IX_Enrolls_CourseId",
                table: "Enrolls",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_Courses_CourseId",
                table: "Enrolls",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseCode",
                onDelete: ReferentialAction.Cascade);

            

            migrationBuilder.AddForeignKey(
                name: "FK_Teaches_Courses_CourseId",
                table: "Teaches",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
