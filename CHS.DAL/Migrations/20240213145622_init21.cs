using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TimeTables_SemesterTitle",
                table: "TimeTables");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_SemesterTitle",
                table: "TimeTables",
                column: "SemesterTitle",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TimeTables_SemesterTitle",
                table: "TimeTables");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_SemesterTitle",
                table: "TimeTables",
                column: "SemesterTitle");
        }
    }
}
