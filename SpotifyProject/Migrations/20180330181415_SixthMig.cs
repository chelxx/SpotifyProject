using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SpotifyProject.Migrations
{
    public partial class SixthMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrackName",
                table: "Tracks",
                newName: "data_track");

            migrationBuilder.RenameColumn(
                name: "Artist",
                table: "Tracks",
                newName: "data_artist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "data_track",
                table: "Tracks",
                newName: "TrackName");

            migrationBuilder.RenameColumn(
                name: "data_artist",
                table: "Tracks",
                newName: "Artist");
        }
    }
}
