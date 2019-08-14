using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Persistent.Mapping
{
    public class ArtistMapping : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.NameArtist).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Country).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Gender).HasMaxLength(1).IsRequired();

            builder.HasMany(p => p.Albums)
                .WithOne(p => p.Artist)
                .HasForeignKey(p => p.ArtistId);
        }
    }
}
