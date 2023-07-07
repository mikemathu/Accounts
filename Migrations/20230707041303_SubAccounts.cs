using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Migrations
{
    /// <inheritdoc />
    public partial class SubAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubAccountDetailSubAccountID",
                table: "SubAccountsDetails",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubAccountsDetails_SubAccountDetailSubAccountID",
                table: "SubAccountsDetails",
                column: "SubAccountDetailSubAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubAccountsDetails_SubAccountsDetails_SubAccountDetailSubAc~",
                table: "SubAccountsDetails",
                column: "SubAccountDetailSubAccountID",
                principalTable: "SubAccountsDetails",
                principalColumn: "SubAccountID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubAccountsDetails_SubAccountsDetails_SubAccountDetailSubAc~",
                table: "SubAccountsDetails");

            migrationBuilder.DropIndex(
                name: "IX_SubAccountsDetails_SubAccountDetailSubAccountID",
                table: "SubAccountsDetails");

            migrationBuilder.DropColumn(
                name: "SubAccountDetailSubAccountID",
                table: "SubAccountsDetails");
        }
    }
}
