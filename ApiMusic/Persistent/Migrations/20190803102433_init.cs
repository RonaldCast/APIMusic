using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistent.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NameArtist = table.Column<string>(maxLength: 30, nullable: false),
                    Country = table.Column<string>(maxLength: 30, nullable: false),
                    Gender = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(maxLength: 75, nullable: false),
                    Password = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    DatePublic = table.Column<DateTimeOffset>(nullable: false),
                    ArtistId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 40, nullable: true),
                    Description = table.Column<string>(maxLength: 75, nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Duration = table.Column<string>(maxLength: 10, nullable: false),
                    DatePublic = table.Column<DateTimeOffset>(nullable: false),
                    AlbumId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musics_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicArtist",
                columns: table => new
                {
                    MusicId = table.Column<Guid>(nullable: false),
                    ArtistId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicArtist", x => new { x.ArtistId, x.MusicId });
                    table.ForeignKey(
                        name: "FK_MusicArtist_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicArtist_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayListMusic",
                columns: table => new
                {
                    PlayListId = table.Column<Guid>(nullable: false),
                    MusicId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayListMusic", x => new { x.MusicId, x.PlayListId });
                    table.ForeignKey(
                        name: "FK_PlayListMusic_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayListMusic_PlayLists_PlayListId",
                        column: x => x.PlayListId,
                        principalTable: "PlayLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicArtist_MusicId",
                table: "MusicArtist",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_AlbumId",
                table: "Musics",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_People_UserID",
                table: "People",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayListMusic_PlayListId",
                table: "PlayListMusic",
                column: "PlayListId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayLists_UserId",
                table: "PlayLists",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicArtist");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "PlayListMusic");

            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.DropTable(
                name: "PlayLists");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
