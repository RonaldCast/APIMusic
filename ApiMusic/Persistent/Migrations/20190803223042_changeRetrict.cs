using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistent.Migrations
{
    public partial class changeRetrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicArtist_Musics_MusicId",
                table: "MusicArtist");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicArtist_Musics_MusicId",
                table: "MusicArtist",
                column: "MusicId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicArtist_Musics_MusicId",
                table: "MusicArtist");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicArtist_Musics_MusicId",
                table: "MusicArtist",
                column: "MusicId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
