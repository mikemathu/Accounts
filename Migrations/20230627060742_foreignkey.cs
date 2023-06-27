using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_subsccountdetails_AccountDetailId",
                table: "subsccountdetails",
                column: "AccountDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_subsccountdetails_accountdetails_AccountDetailId",
                table: "subsccountdetails",
                column: "AccountDetailId",
                principalTable: "accountdetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subsccountdetails_accountdetails_AccountDetailId",
                table: "subsccountdetails");

            migrationBuilder.DropIndex(
                name: "IX_subsccountdetails_AccountDetailId",
                table: "subsccountdetails");
        }
    }
}
