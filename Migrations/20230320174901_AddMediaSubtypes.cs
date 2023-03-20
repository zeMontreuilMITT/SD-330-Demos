using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SD_330_Demos.Migrations
{
    public partial class AddMediaSubtypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Song",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_Song_AlbumId",
                table: "Song");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Song");

            migrationBuilder.RenameTable(
                name: "Song",
                newName: "Media");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "MediaCollection");

            migrationBuilder.AddColumn<DateTime>(
                name: "AirDate",
                table: "Media",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaCollectionId",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "media_type",
                table: "Media",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "mcollection_type",
                table: "MediaCollection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Media",
                table: "Media",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaCollection",
                table: "MediaCollection",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Media_MediaCollectionId",
                table: "Media",
                column: "MediaCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_MediaCollection_MediaCollectionId",
                table: "Media",
                column: "MediaCollectionId",
                principalTable: "MediaCollection",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_MediaCollection_MediaCollectionId",
                table: "Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaCollection",
                table: "MediaCollection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Media",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_MediaCollectionId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "mcollection_type",
                table: "MediaCollection");

            migrationBuilder.DropColumn(
                name: "AirDate",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "MediaCollectionId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "media_type",
                table: "Media");

            migrationBuilder.RenameTable(
                name: "MediaCollection",
                newName: "Album");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Song");

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Song",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Song",
                table: "Song",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Song_AlbumId",
                table: "Song",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
