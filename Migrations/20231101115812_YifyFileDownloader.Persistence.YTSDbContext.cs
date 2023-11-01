using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YifyFileDownloader.Migrations
{
    /// <inheritdoc />
    public partial class YifyFileDownloaderPersistenceYTSDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "API",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    API_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    API_ENDPOINT = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    API_PAYLOAD = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    API_RESPONSE = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    DELETED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MovieDetails",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MOVIE_ID = table.Column<int>(type: "int", nullable: false),
                    MOVIE_URL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MOVIE_TITLE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MOVIE_ENGLISH_TITLE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MOVIE_LONG_TITLE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IMDB_CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RELEASE_YEAR = table.Column<int>(type: "int", nullable: false),
                    RATING = table.Column<double>(type: "float", nullable: false),
                    MOVIE_LENGTH = table.Column<int>(type: "int", nullable: false),
                    GENRES = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MOVIE_LANGUAGE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    DELETED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TORRENT_DETAILS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TORRENT_URL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TORRENT_HASH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TORRENT_QUALITY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TORRENT_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MOVIE_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    DELETED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TORRENT_DETAILS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TORRENT_DETAILS_MovieDetails_MOVIE_ID",
                        column: x => x.MOVIE_ID,
                        principalTable: "MovieDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TORRENT_DETAILS_MOVIE_ID",
                table: "TORRENT_DETAILS",
                column: "MOVIE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "API");

            migrationBuilder.DropTable(
                name: "TORRENT_DETAILS");

            migrationBuilder.DropTable(
                name: "MovieDetails");
        }
    }
}
