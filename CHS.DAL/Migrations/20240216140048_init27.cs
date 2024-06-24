using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lectures_IntervalIdFk",
                table: "Lectures");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_IntervalIdFk",
                table: "Lectures",
                column: "IntervalIdFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lectures_IntervalIdFk",
                table: "Lectures");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_IntervalIdFk",
                table: "Lectures",
                column: "IntervalIdFk",
                unique: true);
        }
    }
}
