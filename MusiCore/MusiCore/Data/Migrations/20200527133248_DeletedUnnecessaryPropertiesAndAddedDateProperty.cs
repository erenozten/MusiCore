using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusiCore.Data.Migrations
{
    public partial class DeletedUnnecessaryPropertiesAndAddedDateProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreatedAndCompleted",
                table: "UsedTechnologies");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CampaignOfAddingNewModules");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "LogOfEverythings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "CampaignOfFixations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "LogOfEverythings");

            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "CampaignOfFixations");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreatedAndCompleted",
                table: "UsedTechnologies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CampaignOfAddingNewModules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
