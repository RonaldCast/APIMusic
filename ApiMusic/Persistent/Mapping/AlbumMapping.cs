using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistent.Mapping
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Description).HasMaxLength(50);

            builder.Property(p => p.DatePublic).IsRequired();
            builder.HasMany(p => p.Musics)
                .WithOne(p => p.Album)
                .HasForeignKey(p => p.AlbumId);


        }
    }
}
