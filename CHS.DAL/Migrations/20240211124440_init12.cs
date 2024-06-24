using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_ClassRooms_ClassIdFk",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CourseIdFk",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_TimeTables_TableIdFk",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_Semesters_SemesterTitleFk",
                table: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_TimeTables_SemesterTitleFk",
                table: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_ClassIdFk",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_CourseIdFk",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_TableIdFk",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "SemesterTitleFk",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "ClassIdFk",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "CourseIdFk",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "TableIdFk",
                table: "Lectures");

            migrationBuilder.AlterColumn<string>(
                name: "SemesterTitle",
                table: "TimeTables",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "Lectures",
                type: "nvarchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_SemesterTitle",
                table: "TimeTables",
                column: "SemesterTitle");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_ClassRoomId",
                table: "Lectures",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseId",
                table: "Lectures",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_TimeTableId",
                table: "Lectures",
                column: "TimeTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_ClassRooms_ClassRoomId",
                table: "Lectures",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_TimeTables_TimeTableId",
                table: "Lectures",
                column: "TimeTableId",
                principalTable: "TimeTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_Semesters_SemesterTitle",
                table: "TimeTables",
                column: "SemesterTitle",
                principalTable: "Semesters",
                principalColumn: "SemesterTitle",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_ClassRooms_ClassRoomId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_TimeTables_TimeTableId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_Semesters_SemesterTitle",
                table: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_TimeTables_SemesterTitle",
                table: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_ClassRoomId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_CourseId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_TimeTableId",
                table: "Lectures");

            migrationBuilder.AlterColumn<string>(
                name: "SemesterTitle",
                table: "TimeTables",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddColumn<string>(
                name: "SemesterTitleFk",
                table: "TimeTables",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)");

            migrationBuilder.AddColumn<int>(
                name: "ClassIdFk",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CourseIdFk",
                table: "Lectures",
                type: "nvarchar(5)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TableIdFk",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_SemesterTitleFk",
                table: "TimeTables",
                column: "SemesterTitleFk");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_ClassIdFk",
                table: "Lectures",
                column: "ClassIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseIdFk",
                table: "Lectures",
                column: "CourseIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_TableIdFk",
                table: "Lectures",
                column: "TableIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_ClassRooms_ClassIdFk",
                table: "Lectures",
                column: "ClassIdFk",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CourseIdFk",
                table: "Lectures",
                column: "CourseIdFk",
                principalTable: "Courses",
                principalColumn: "CourseCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_TimeTables_TableIdFk",
                table: "Lectures",
                column: "TableIdFk",
                principalTable: "TimeTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_Semesters_SemesterTitleFk",
                table: "TimeTables",
                column: "SemesterTitleFk",
                principalTable: "Semesters",
                principalColumn: "SemesterTitle");
        }
    }
}
