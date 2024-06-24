using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseGroup_Courses_CourseCode",
                table: "CourseGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseGroup_Semesters_SemesterTitle",
                table: "CourseGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_CourseGroup_CourseGroupId",
                table: "Enrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_CourseGroup_CourseGroupId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Interval_IntervalIdFk",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Teaches_CourseGroup_CourseGroupId",
                table: "Teaches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interval",
                table: "Interval");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseGroup",
                table: "CourseGroup");

            migrationBuilder.RenameTable(
                name: "Interval",
                newName: "Intervals");

            migrationBuilder.RenameTable(
                name: "CourseGroup",
                newName: "CourseGroups");

            migrationBuilder.RenameIndex(
                name: "IX_CourseGroup_SemesterTitle",
                table: "CourseGroups",
                newName: "IX_CourseGroups_SemesterTitle");

            migrationBuilder.RenameIndex(
                name: "IX_CourseGroup_CourseCode",
                table: "CourseGroups",
                newName: "IX_CourseGroups_CourseCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Intervals",
                table: "Intervals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseGroups",
                table: "CourseGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseGroups_Courses_CourseCode",
                table: "CourseGroups",
                column: "CourseCode",
                principalTable: "Courses",
                principalColumn: "CourseCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseGroups_Semesters_SemesterTitle",
                table: "CourseGroups",
                column: "SemesterTitle",
                principalTable: "Semesters",
                principalColumn: "SemesterTitle",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_CourseGroups_CourseGroupId",
                table: "Enrolls",
                column: "CourseGroupId",
                principalTable: "CourseGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_CourseGroups_CourseGroupId",
                table: "Lectures",
                column: "CourseGroupId",
                principalTable: "CourseGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Intervals_IntervalIdFk",
                table: "Lectures",
                column: "IntervalIdFk",
                principalTable: "Intervals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teaches_CourseGroups_CourseGroupId",
                table: "Teaches",
                column: "CourseGroupId",
                principalTable: "CourseGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseGroups_Courses_CourseCode",
                table: "CourseGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseGroups_Semesters_SemesterTitle",
                table: "CourseGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_CourseGroups_CourseGroupId",
                table: "Enrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_CourseGroups_CourseGroupId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Intervals_IntervalIdFk",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Teaches_CourseGroups_CourseGroupId",
                table: "Teaches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Intervals",
                table: "Intervals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseGroups",
                table: "CourseGroups");

            migrationBuilder.RenameTable(
                name: "Intervals",
                newName: "Interval");

            migrationBuilder.RenameTable(
                name: "CourseGroups",
                newName: "CourseGroup");

            migrationBuilder.RenameIndex(
                name: "IX_CourseGroups_SemesterTitle",
                table: "CourseGroup",
                newName: "IX_CourseGroup_SemesterTitle");

            migrationBuilder.RenameIndex(
                name: "IX_CourseGroups_CourseCode",
                table: "CourseGroup",
                newName: "IX_CourseGroup_CourseCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interval",
                table: "Interval",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseGroup",
                table: "CourseGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseGroup_Courses_CourseCode",
                table: "CourseGroup",
                column: "CourseCode",
                principalTable: "Courses",
                principalColumn: "CourseCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseGroup_Semesters_SemesterTitle",
                table: "CourseGroup",
                column: "SemesterTitle",
                principalTable: "Semesters",
                principalColumn: "SemesterTitle",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_CourseGroup_CourseGroupId",
                table: "Enrolls",
                column: "CourseGroupId",
                principalTable: "CourseGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_CourseGroup_CourseGroupId",
                table: "Lectures",
                column: "CourseGroupId",
                principalTable: "CourseGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Interval_IntervalIdFk",
                table: "Lectures",
                column: "IntervalIdFk",
                principalTable: "Interval",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teaches_CourseGroup_CourseGroupId",
                table: "Teaches",
                column: "CourseGroupId",
                principalTable: "CourseGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
