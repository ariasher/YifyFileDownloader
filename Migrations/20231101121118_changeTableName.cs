using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YifyFileDownloader.Migrations
{
    /// <inheritdoc />
    public partial class changeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TORRENT_DETAILS_MovieDetails_MOVIE_ID",
                table: "TORRENT_DETAILS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieDetails",
                table: "MovieDetails");

            migrationBuilder.RenameTable(
                name: "MovieDetails",
                newName: "MOVIE_DETAILS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MOVIE_DETAILS",
                table: "MOVIE_DETAILS",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TORRENT_DETAILS_MOVIE_DETAILS_MOVIE_ID",
                table: "TORRENT_DETAILS",
                column: "MOVIE_ID",
                principalTable: "MOVIE_DETAILS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TORRENT_DETAILS_MOVIE_DETAILS_MOVIE_ID",
                table: "TORRENT_DETAILS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MOVIE_DETAILS",
                table: "MOVIE_DETAILS");

            migrationBuilder.RenameTable(
                name: "MOVIE_DETAILS",
                newName: "MovieDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieDetails",
                table: "MovieDetails",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TORRENT_DETAILS_MovieDetails_MOVIE_ID",
                table: "TORRENT_DETAILS",
                column: "MOVIE_ID",
                principalTable: "MovieDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
