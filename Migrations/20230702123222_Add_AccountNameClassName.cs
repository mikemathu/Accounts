using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Migrations
{
    /// <inheritdoc />
    public partial class Add_AccountNameClassName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AccountsDetails",
                newName: "AccountName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AccountClasses",
                newName: "ClassName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountName",
                table: "AccountsDetails",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ClassName",
                table: "AccountClasses",
                newName: "Name");
        }
    }
}
