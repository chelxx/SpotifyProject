using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SpotifyProject.Migrations
{
    public partial class ThirdMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_Playlists_PlaylistId",
                table: "Track");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_Users_UserId",
                table: "Track");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Track",
                table: "Track");

            migrationBuilder.RenameTable(
                name: "Track",
                newName: "Tracks");

            migrationBuilder.RenameIndex(
                name: "IX_Track_UserId",
                table: "Tracks",
                newName: "IX_Tracks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Track_PlaylistId",
                table: "Tracks",
                newName: "IX_Tracks_PlaylistId");

            migrationBuilder.AlterColumn<int>(
                name: "PlaylistId",
                table: "Tracks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tracks",
                table: "Tracks",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Playlists_PlaylistId",
                table: "Tracks",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Users_UserId",
                table: "Tracks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Playlists_PlaylistId",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Users_UserId",
                table: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tracks",
                table: "Tracks");

            migrationBuilder.RenameTable(
                name: "Tracks",
                newName: "Track");

            migrationBuilder.RenameIndex(
                name: "IX_Tracks_UserId",
                table: "Track",
                newName: "IX_Track_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tracks_PlaylistId",
                table: "Track",
                newName: "IX_Track_PlaylistId");

            migrationBuilder.AlterColumn<int>(
                name: "PlaylistId",
                table: "Track",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Track",
                table: "Track",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Playlists_PlaylistId",
                table: "Track",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Users_UserId",
                table: "Track",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
