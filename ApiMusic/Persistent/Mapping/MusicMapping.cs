using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Persistent.Mapping
{
    public class MusicMapping : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Duration).HasMaxLength(10).IsRequired();
            builder.Property(p => p.DatePublic).IsRequired();

            builder.HasOne(p => p.Album)
                .WithMany(p => p.Musics)
                .HasForeignKey(p => p.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
