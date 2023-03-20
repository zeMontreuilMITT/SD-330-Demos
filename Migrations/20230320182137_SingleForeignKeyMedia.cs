using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SD_330_Demos.Migrations
{
    public partial class SingleForeignKeyMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_MediaCollection_AlbumId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_MediaCollection_PodcastId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_AlbumId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_PodcastId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "PodcastId",
                table: "Media");

            migrationBuilder.CreateIndex(
                name: "IX_Media_MediaCollectionId",
                table: "Media",
                column: "MediaCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_MediaCollection_MediaCollectionId",
                table: "Media",
                column: "MediaCollectionId",
                principalTable: "MediaCollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_MediaCollection_MediaCollectionId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_MediaCollectionId",
                table: "Media");

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PodcastId",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_AlbumId",
                table: "Media",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_PodcastId",
                table: "Media",
                column: "PodcastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_MediaCollection_AlbumId",
                table: "Media",
                column: "AlbumId",
                principalTable: "MediaCollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_MediaCollection_PodcastId",
                table: "Media",
                column: "PodcastId",
                principalTable: "MediaCollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
