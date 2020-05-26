using Microsoft.EntityFrameworkCore.Migrations;

namespace MusiCore.Data.Migrations
{
    public partial class AddedLogAndAllOtherTablesAboutAddingTextsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignOfAddingNewModules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextTurkish = table.Column<string>(nullable: true),
                    TextEnglish = table.Column<string>(nullable: true),
                    IsDone = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignOfAddingNewModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogOfEverythings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextTurkish = table.Column<string>(nullable: true),
                    TextEnglish = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogOfEverythings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsedApproaches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextTurkish = table.Column<string>(nullable: true),
                    TextEnglish = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedApproaches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsedTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextTurkish = table.Column<string>(nullable: true),
                    TextEnglish = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedTechnologies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignOfAddingNewModules");

            migrationBuilder.DropTable(
                name: "LogOfEverythings");

            migrationBuilder.DropTable(
                name: "UsedApproaches");

            migrationBuilder.DropTable(
                name: "UsedTechnologies");
        }
    }
}
