using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Migrations
{
    /// <inheritdoc />
    public partial class Addfiscalperiods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FiscalPeriods",
                table: "FiscalPeriods");

            migrationBuilder.RenameTable(
                name: "FiscalPeriods",
                newName: "FiscalPeriod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FiscalPeriod",
                table: "FiscalPeriod",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FiscalPeriod",
                table: "FiscalPeriod");

            migrationBuilder.RenameTable(
                name: "FiscalPeriod",
                newName: "FiscalPeriods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FiscalPeriods",
                table: "FiscalPeriods",
                column: "Id");
        }
    }
}
