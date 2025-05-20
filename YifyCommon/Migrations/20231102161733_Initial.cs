using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YifyCommon.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "API",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    API_NAME = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    API_ENDPOINT = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    API_PAYLOAD = table.Column<string>(type: "TEXT", maxLength: 400, nullable: false),
                    API_RESPONSE = table.Column<string>(type: "blob", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    DELETED_AT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INSTANCE_LOGS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RAN_SUCCESSFULLY = table.Column<bool>(type: "INTEGER", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    DELETED_AT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSTANCE_LOGS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MOVIE_DETAILS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MOVIE_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    MOVIE_URL = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    MOVIE_TITLE = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MOVIE_ENGLISH_TITLE = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MOVIE_LONG_TITLE = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    IMDB_CODE = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    RELEASE_YEAR = table.Column<int>(type: "INTEGER", nullable: false),
                    RATING = table.Column<double>(type: "REAL", nullable: false),
                    MOVIE_LENGTH = table.Column<int>(type: "INTEGER", nullable: false),
                    GENRES = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    MOVIE_LANGUAGE = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    DELETED_AT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIE_DETAILS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TORRENT_DETAILS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TORRENT_URL = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    TORRENT_HASH = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TORRENT_QUALITY = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TORRENT_TYPE = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MOVIE_ID = table.Column<long>(type: "INTEGER", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    DELETED_AT = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TORRENT_DETAILS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TORRENT_DETAILS_MOVIE_DETAILS_MOVIE_ID",
                        column: x => x.MOVIE_ID,
                        principalTable: "MOVIE_DETAILS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_API_CREATED_AT",
                table: "API",
                column: "CREATED_AT");

            migrationBuilder.CreateIndex(
                name: "IX_API_DELETED_AT",
                table: "API",
                column: "DELETED_AT");

            migrationBuilder.CreateIndex(
                name: "IX_API_IS_ACTIVE",
                table: "API",
                column: "IS_ACTIVE");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCE_LOGS_CREATED_AT",
                table: "INSTANCE_LOGS",
                column: "CREATED_AT");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCE_LOGS_DELETED_AT",
                table: "INSTANCE_LOGS",
                column: "DELETED_AT");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCE_LOGS_IS_ACTIVE",
                table: "INSTANCE_LOGS",
                column: "IS_ACTIVE");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCE_LOGS_RAN_SUCCESSFULLY",
                table: "INSTANCE_LOGS",
                column: "RAN_SUCCESSFULLY");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIE_DETAILS_CREATED_AT",
                table: "MOVIE_DETAILS",
                column: "CREATED_AT");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIE_DETAILS_DELETED_AT",
                table: "MOVIE_DETAILS",
                column: "DELETED_AT");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIE_DETAILS_GENRES",
                table: "MOVIE_DETAILS",
                column: "GENRES");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIE_DETAILS_IS_ACTIVE",
                table: "MOVIE_DETAILS",
                column: "IS_ACTIVE");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIE_DETAILS_MOVIE_ENGLISH_TITLE",
                table: "MOVIE_DETAILS",
                column: "MOVIE_ENGLISH_TITLE");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIE_DETAILS_MOVIE_ID",
                table: "MOVIE_DETAILS",
                column: "MOVIE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIE_DETAILS_MOVIE_LANGUAGE",
                table: "MOVIE_DETAILS",
                column: "MOVIE_LANGUAGE");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIE_DETAILS_MOVIE_LENGTH",
                table: "MOVIE_DETAILS",
                column: "MOVIE_LENGTH");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIE_DETAILS_MOVIE_TITLE",
                table: "MOVIE_DETAILS",
                column: "MOVIE_TITLE");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIE_DETAILS_RATING",
                table: "MOVIE_DETAILS",
                column: "RATING");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIE_DETAILS_RELEASE_YEAR",
                table: "MOVIE_DETAILS",
                column: "RELEASE_YEAR");

            migrationBuilder.CreateIndex(
                name: "IX_TORRENT_DETAILS_CREATED_AT",
                table: "TORRENT_DETAILS",
                column: "CREATED_AT");

            migrationBuilder.CreateIndex(
                name: "IX_TORRENT_DETAILS_DELETED_AT",
                table: "TORRENT_DETAILS",
                column: "DELETED_AT");

            migrationBuilder.CreateIndex(
                name: "IX_TORRENT_DETAILS_IS_ACTIVE",
                table: "TORRENT_DETAILS",
                column: "IS_ACTIVE");

            migrationBuilder.CreateIndex(
                name: "IX_TORRENT_DETAILS_MOVIE_ID",
                table: "TORRENT_DETAILS",
                column: "MOVIE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TORRENT_DETAILS_TORRENT_QUALITY",
                table: "TORRENT_DETAILS",
                column: "TORRENT_QUALITY");

            migrationBuilder.CreateIndex(
                name: "IX_TORRENT_DETAILS_TORRENT_TYPE",
                table: "TORRENT_DETAILS",
                column: "TORRENT_TYPE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "API");

            migrationBuilder.DropTable(
                name: "INSTANCE_LOGS");

            migrationBuilder.DropTable(
                name: "TORRENT_DETAILS");

            migrationBuilder.DropTable(
                name: "MOVIE_DETAILS");
        }
    }
}
