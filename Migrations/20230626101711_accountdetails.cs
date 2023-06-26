using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Migrations
{
    /// <inheritdoc />
    public partial class accountdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountDetails",
                table: "AccountDetails");

            migrationBuilder.RenameTable(
                name: "AccountDetails",
                newName: "accountdetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TrasnactionDate",
                table: "JournalVouchers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "fiscalperiods",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseDate",
                table: "fiscalperiods",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountdetails",
                table: "accountdetails",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_accountdetails",
                table: "accountdetails");

            migrationBuilder.RenameTable(
                name: "accountdetails",
                newName: "AccountDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TrasnactionDate",
                table: "JournalVouchers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenDate",
                table: "fiscalperiods",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseDate",
                table: "fiscalperiods",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountDetails",
                table: "AccountDetails",
                column: "Id");
        }
    }
}
