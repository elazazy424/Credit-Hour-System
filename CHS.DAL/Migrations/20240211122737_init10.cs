using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassRoomId",
                table: "TimeTables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassRoomId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    TimeTableId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lectures_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lectures_TimeTables_TimeTableId",
                        column: x => x.TimeTableId,
                        principalTable: "TimeTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_ClassRoomId",
                table: "TimeTables",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ClassRoomId",
                table: "Courses",
                column: "ClassRoomId");

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
                name: "FK_Courses_ClassRooms_ClassRoomId",
                table: "Courses",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_ClassRooms_ClassRoomId",
                table: "TimeTables",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_ClassRooms_ClassRoomId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_ClassRooms_ClassRoomId",
                table: "TimeTables");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_TimeTables_ClassRoomId",
                table: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ClassRoomId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                table: "Courses");
        }
    }
}
