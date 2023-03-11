using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToeApi.Migrations
{
    /// <inheritdoc />
    public partial class MbLastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Board",
                table: "TTTes",
                type: "text",
                nullable: false,
                oldClrType: typeof(char[]),
                oldType: "character(1)[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char[]>(
                name: "Board",
                table: "TTTes",
                type: "character(1)[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
