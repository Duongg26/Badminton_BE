using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Badminton_BE.Migrations
{
    /// <inheritdoc />
    public partial class addPass2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pass2",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pass2",
                table: "Accounts");
        }
    }
}
