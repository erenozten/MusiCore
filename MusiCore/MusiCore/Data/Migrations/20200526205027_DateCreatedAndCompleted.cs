using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusiCore.Data.Migrations
{
    public partial class DateCreatedAndCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreatedAndCompleted",
                table: "UsedTechnologies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreatedAndCompleted",
                table: "UsedTechnologies");
        }
    }
}
