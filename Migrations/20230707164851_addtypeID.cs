using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Migrations
{
    /// <inheritdoc />
    public partial class addtypeID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "CashFlowCategories");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AccountTypes",
                newName: "TypeName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AccountTypes",
                newName: "AccountTypeID");

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeID",
                table: "CashFlowCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowCategories_AccountTypeID",
                table: "CashFlowCategories",
                column: "AccountTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlowCategories_AccountTypes_AccountTypeID",
                table: "CashFlowCategories",
                column: "AccountTypeID",
                principalTable: "AccountTypes",
                principalColumn: "AccountTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashFlowCategories_AccountTypes_AccountTypeID",
                table: "CashFlowCategories");

            migrationBuilder.DropIndex(
                name: "IX_CashFlowCategories_AccountTypeID",
                table: "CashFlowCategories");

            migrationBuilder.DropColumn(
                name: "AccountTypeID",
                table: "CashFlowCategories");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "AccountTypes",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AccountTypeID",
                table: "AccountTypes",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "CashFlowCategories",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
