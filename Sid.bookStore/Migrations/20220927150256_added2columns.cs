using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sid.bookStore.Migrations
{
    public partial class added2columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Book",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Book",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Book");
        }
    }
}
