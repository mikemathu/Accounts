using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Migrations
{
    /// <inheritdoc />
    public partial class Addfiscalperiodsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FiscalPeriod",
                table: "FiscalPeriod");

            migrationBuilder.RenameTable(
                name: "FiscalPeriod",
                newName: "fiscalperiods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fiscalperiods",
                table: "fiscalperiods",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_fiscalperiods",
                table: "fiscalperiods");

            migrationBuilder.RenameTable(
                name: "fiscalperiods",
                newName: "FiscalPeriod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FiscalPeriod",
                table: "FiscalPeriod",
                column: "Id");
        }
    }
}
