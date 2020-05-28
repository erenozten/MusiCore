using Microsoft.EntityFrameworkCore.Migrations;

namespace MusiCore.Data.Migrations
{
    public partial class AddAttendanceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Concerts_AspNetUsers_ArtistId",
            //    table: "Concerts");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Concerts_Genres_GenreId",
            //    table: "Concerts");

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    ConcertId = table.Column<int>(nullable: false),
                    AttendeeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => new { x.ConcertId, x.AttendeeId });
                    table.ForeignKey(
                        name: "FK_Attendances_AspNetUsers_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendances_Concerts_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_AttendeeId",
                table: "Attendances",
                column: "AttendeeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Concerts_AspNetUsers_ArtistId",
            //    table: "Concerts",
            //    column: "ArtistId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Concerts_Genres_GenreId",
            //    table: "Concerts",
            //    column: "GenreId",
            //    principalTable: "Genres",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_AspNetUsers_ArtistId",
                table: "Concerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Genres_GenreId",
                table: "Concerts");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_AspNetUsers_ArtistId",
                table: "Concerts",
                column: "ArtistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Genres_GenreId",
                table: "Concerts",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
