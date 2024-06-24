using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Lectures_ClassRoomId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_CourseId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_TimeTableId",
                table: "Lectures");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "Lectures",
                newName: "TableIdFk");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Lectures",
                newName: "ClassIdFk");

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)");

            migrationBuilder.AddColumn<string>(
                name: "CourseIdFk",
                table: "Lectures",
                type: "nvarchar(5)",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "CourseIdFk",
                table: "Lectures");

            migrationBuilder.RenameColumn(
                name: "TableIdFk",
                table: "Lectures",
                newName: "TableId");

            migrationBuilder.RenameColumn(
                name: "ClassIdFk",
                table: "Lectures",
                newName: "ClassId");

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "Lectures",
                type: "nvarchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }
    }
}
