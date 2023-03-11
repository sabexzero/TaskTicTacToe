using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToeApi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Board",
                table: "TTTes");

            migrationBuilder.DropColumn(
                name: "CurrentTurn",
                table: "TTTes");

            migrationBuilder.DropColumn(
                name: "Oid",
                table: "TTTes");

            migrationBuilder.DropColumn(
                name: "Winner",
                table: "TTTes");

            migrationBuilder.DropColumn(
                name: "Xid",
                table: "TTTes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<char[]>(
                name: "Board",
                table: "TTTes",
                type: "character(1)[]",
                nullable: false,
                defaultValue: new char[0]);

            migrationBuilder.AddColumn<bool>(
                name: "CurrentTurn",
                table: "TTTes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Oid",
                table: "TTTes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "TTTes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Xid",
                table: "TTTes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
