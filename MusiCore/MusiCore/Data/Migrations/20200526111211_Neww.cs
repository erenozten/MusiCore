using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusiCore.Data.Migrations
{
    public partial class Neww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "CampaignOfAddingNewModules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "CampaignOfAddingNewModules");
        }
    }
}
