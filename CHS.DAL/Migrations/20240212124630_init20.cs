using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IntervalIdFk",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Interval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartInterval = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    EndInterval = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interval", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_IntervalIdFk",
                table: "Lectures",
                column: "IntervalIdFk",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Interval_IntervalIdFk",
                table: "Lectures",
                column: "IntervalIdFk",
                principalTable: "Interval",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Interval_IntervalIdFk",
                table: "Lectures");

            migrationBuilder.DropTable(
                name: "Interval");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_IntervalIdFk",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "IntervalIdFk",
                table: "Lectures");
        }
    }
}
