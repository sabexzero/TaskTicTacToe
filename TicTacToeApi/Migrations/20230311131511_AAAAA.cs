using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToeApi.Migrations
{
    /// <inheritdoc />
    public partial class AAAAA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "CurrentTurn",
                table: "TTTes",
                type: "character(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "CurrentTurn",
                table: "TTTes",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(1)");
        }
    }
}
