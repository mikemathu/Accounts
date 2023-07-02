using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBackfieldcase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accountsdetails_CashFlowCategories_CashFlowCategoryID",
                table: "accountsdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_accountsdetails_Configurations_ConfigurationType",
                table: "accountsdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_accountsdetails_accountclasses_accountclassid",
                table: "accountsdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SubAccountsDetails_accountsdetails_AccountID",
                table: "SubAccountsDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accountsdetails",
                table: "accountsdetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accountclasses",
                table: "accountclasses");

            migrationBuilder.RenameTable(
                name: "accountsdetails",
                newName: "AccountsDetails");

            migrationBuilder.RenameTable(
                name: "accountclasses",
                newName: "AccountClasses");

            migrationBuilder.RenameColumn(
                name: "accountno",
                table: "AccountsDetails",
                newName: "AccountNo");

            migrationBuilder.RenameColumn(
                name: "accountname",
                table: "AccountsDetails",
                newName: "AccountName");

            migrationBuilder.RenameColumn(
                name: "accountclassid",
                table: "AccountsDetails",
                newName: "AccountClassID");

            migrationBuilder.RenameColumn(
                name: "accountid",
                table: "AccountsDetails",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_accountsdetails_ConfigurationType",
                table: "AccountsDetails",
                newName: "IX_AccountsDetails_ConfigurationType");

            migrationBuilder.RenameIndex(
                name: "IX_accountsdetails_CashFlowCategoryID",
                table: "AccountsDetails",
                newName: "IX_AccountsDetails_CashFlowCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_accountsdetails_accountclassid",
                table: "AccountsDetails",
                newName: "IX_AccountsDetails_AccountClassID");

            migrationBuilder.RenameColumn(
                name: "classname",
                table: "AccountClasses",
                newName: "ClassName");

            migrationBuilder.RenameColumn(
                name: "accountclassid",
                table: "AccountClasses",
                newName: "AccountClassID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountsDetails",
                table: "AccountsDetails",
                column: "AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountClasses",
                table: "AccountClasses",
                column: "AccountClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDetails_AccountClasses_AccountClassID",
                table: "AccountsDetails",
                column: "AccountClassID",
                principalTable: "AccountClasses",
                principalColumn: "AccountClassID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDetails_CashFlowCategories_CashFlowCategoryID",
                table: "AccountsDetails",
                column: "CashFlowCategoryID",
                principalTable: "CashFlowCategories",
                principalColumn: "CashFlowCategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDetails_Configurations_ConfigurationType",
                table: "AccountsDetails",
                column: "ConfigurationType",
                principalTable: "Configurations",
                principalColumn: "ConfigurationType",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubAccountsDetails_AccountsDetails_AccountID",
                table: "SubAccountsDetails",
                column: "AccountID",
                principalTable: "AccountsDetails",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDetails_AccountClasses_AccountClassID",
                table: "AccountsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDetails_CashFlowCategories_CashFlowCategoryID",
                table: "AccountsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDetails_Configurations_ConfigurationType",
                table: "AccountsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SubAccountsDetails_AccountsDetails_AccountID",
                table: "SubAccountsDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountsDetails",
                table: "AccountsDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountClasses",
                table: "AccountClasses");

            migrationBuilder.RenameTable(
                name: "AccountsDetails",
                newName: "accountsdetails");

            migrationBuilder.RenameTable(
                name: "AccountClasses",
                newName: "accountclasses");

            migrationBuilder.RenameColumn(
                name: "AccountNo",
                table: "accountsdetails",
                newName: "accountno");

            migrationBuilder.RenameColumn(
                name: "AccountName",
                table: "accountsdetails",
                newName: "accountname");

            migrationBuilder.RenameColumn(
                name: "AccountClassID",
                table: "accountsdetails",
                newName: "accountclassid");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "accountsdetails",
                newName: "accountid");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDetails_ConfigurationType",
                table: "accountsdetails",
                newName: "IX_accountsdetails_ConfigurationType");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDetails_CashFlowCategoryID",
                table: "accountsdetails",
                newName: "IX_accountsdetails_CashFlowCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsDetails_AccountClassID",
                table: "accountsdetails",
                newName: "IX_accountsdetails_accountclassid");

            migrationBuilder.RenameColumn(
                name: "ClassName",
                table: "accountclasses",
                newName: "classname");

            migrationBuilder.RenameColumn(
                name: "AccountClassID",
                table: "accountclasses",
                newName: "accountclassid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountsdetails",
                table: "accountsdetails",
                column: "accountid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountclasses",
                table: "accountclasses",
                column: "accountclassid");

            migrationBuilder.AddForeignKey(
                name: "FK_accountsdetails_CashFlowCategories_CashFlowCategoryID",
                table: "accountsdetails",
                column: "CashFlowCategoryID",
                principalTable: "CashFlowCategories",
                principalColumn: "CashFlowCategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_accountsdetails_Configurations_ConfigurationType",
                table: "accountsdetails",
                column: "ConfigurationType",
                principalTable: "Configurations",
                principalColumn: "ConfigurationType",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_accountsdetails_accountclasses_accountclassid",
                table: "accountsdetails",
                column: "accountclassid",
                principalTable: "accountclasses",
                principalColumn: "accountclassid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubAccountsDetails_accountsdetails_AccountID",
                table: "SubAccountsDetails",
                column: "AccountID",
                principalTable: "accountsdetails",
                principalColumn: "accountid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
