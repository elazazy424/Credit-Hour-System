using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstructorType",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OfficeHours",
                table: "Instructors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rank",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructorType",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "OfficeHours",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Instructors");
        }
    }
}
