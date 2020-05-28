using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusiCore.Data.Migrations
{
    public partial class ChangeNameFromDateCompletedToDateCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "LogOfEverythings");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "LogOfEverythings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "LogOfEverythings");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "LogOfEverythings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
