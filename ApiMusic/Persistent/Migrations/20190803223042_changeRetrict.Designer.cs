﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistent;

namespace Persistent.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190803223042_changeRetrict")]
    partial class changeRetrict
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ArtistId");

                    b.Property<DateTimeOffset>("DatePublic");

                    b.Property<string>("Description")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Models.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("NameArtist")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Models.Music", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AlbumId");

                    b.Property<DateTimeOffset>("DatePublic");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Musics");
                });

            modelBuilder.Entity("Models.MusicArtist", b =>
                {
                    b.Property<Guid>("ArtistId");

                    b.Property<Guid>("MusicId");

                    b.HasKey("ArtistId", "MusicId");

                    b.HasIndex("MusicId");

                    b.ToTable("MusicArtist");
                });

            modelBuilder.Entity("Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<Guid>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("People");
                });

            modelBuilder.Entity("Models.PlayList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(75);

                    b.Property<string>("Title")
                        .HasMaxLength(40);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PlayLists");
                });

            modelBuilder.Entity("Models.PlayListMusic", b =>
                {
                    b.Property<Guid>("MusicId");

                    b.Property<Guid>("PlayListId");

                    b.HasKey("MusicId", "PlayListId");

                    b.HasIndex("PlayListId");

                    b.ToTable("PlayListMusic");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(75);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Album", b =>
                {
                    b.HasOne("Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Music", b =>
                {
                    b.HasOne("Models.Album", "Album")
                        .WithMany("Musics")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.MusicArtist", b =>
                {
                    b.HasOne("Models.Artist", "Artist")
                        .WithMany("MusicArtists")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.Music", "Music")
                        .WithMany("MusicArtists")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Person", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithOne("Person")
                        .HasForeignKey("Models.Person", "UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.PlayList", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany("PlayLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.PlayListMusic", b =>
                {
                    b.HasOne("Models.Music", "Music")
                        .WithMany("PlayListMusics")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.PlayList", "PlayList")
                        .WithMany("PlayListMusics")
                        .HasForeignKey("PlayListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
