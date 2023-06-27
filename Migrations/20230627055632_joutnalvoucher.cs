using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Migrations
{
    /// <inheritdoc />
    public partial class joutnalvoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalVouchers",
                table: "JournalVouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubAccountDetails",
                table: "SubAccountDetails");

            migrationBuilder.RenameTable(
                name: "JournalVouchers",
                newName: "journalvouchers");

            migrationBuilder.RenameTable(
                name: "SubAccountDetails",
                newName: "subsccountdetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_journalvouchers",
                table: "journalvouchers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subsccountdetails",
                table: "subsccountdetails",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_journalvouchers",
                table: "journalvouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subsccountdetails",
                table: "subsccountdetails");

            migrationBuilder.RenameTable(
                name: "journalvouchers",
                newName: "JournalVouchers");

            migrationBuilder.RenameTable(
                name: "subsccountdetails",
                newName: "SubAccountDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalVouchers",
                table: "JournalVouchers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubAccountDetails",
                table: "SubAccountDetails",
                column: "Id");
        }
    }
}
