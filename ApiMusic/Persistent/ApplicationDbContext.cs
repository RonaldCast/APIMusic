using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistent.Mapping;

namespace Persistent
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Person> People { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            

            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new PlayListMapping());
            modelBuilder.ApplyConfiguration(new PlayListMusicMapping());
            modelBuilder.ApplyConfiguration(new MusicMapping());
            modelBuilder.ApplyConfiguration(new MusicArtistMapping());
            modelBuilder.ApplyConfiguration(new ArtistMapping());
            modelBuilder.ApplyConfiguration(new AlbumMapping());

        }
    }
}
