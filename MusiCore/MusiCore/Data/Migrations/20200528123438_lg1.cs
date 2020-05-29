using Microsoft.EntityFrameworkCore.Migrations;

namespace MusiCore.Data.Migrations
{
    public partial class lg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_AttendeeId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Concerts_ConcertId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_AspNetUsers_ArtistId",
                table: "Concerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Genres_GenreId",
                table: "Concerts");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_AttendeeId",
                table: "Attendances",
                column: "AttendeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Concerts_ConcertId",
                table: "Attendances",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_AspNetUsers_ArtistId",
                table: "Concerts",
                column: "ArtistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Genres_GenreId",
                table: "Concerts",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_AttendeeId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Concerts_ConcertId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_AspNetUsers_ArtistId",
                table: "Concerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Genres_GenreId",
                table: "Concerts");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_AttendeeId",
                table: "Attendances",
                column: "AttendeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Concerts_ConcertId",
                table: "Attendances",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
