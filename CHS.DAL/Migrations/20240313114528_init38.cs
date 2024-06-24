using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init38 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorksGrade",
                table: "Evaluates",
                newName: "PreFinalGrade");

            migrationBuilder.RenameColumn(
                name: "AttendanceGrade",
                table: "Evaluates",
                newName: "AbsencePercent");

            migrationBuilder.AddColumn<decimal>(
                name: "WeekTwelve",
                table: "Evaluates",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeekTwelve",
                table: "Evaluates");

            migrationBuilder.RenameColumn(
                name: "PreFinalGrade",
                table: "Evaluates",
                newName: "WorksGrade");

            migrationBuilder.RenameColumn(
                name: "AbsencePercent",
                table: "Evaluates",
                newName: "AttendanceGrade");
        }
    }
}
