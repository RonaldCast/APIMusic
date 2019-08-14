using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistent.Mapping
{
    public class MusicArtistMapping : IEntityTypeConfiguration<MusicArtist>
    {
        public void Configure(EntityTypeBuilder<MusicArtist> builder)
        {
            builder.HasKey(k => new { k.ArtistId, k.MusicId });
            

            builder.HasOne(p => p.Artist)
                .WithMany(p => p.MusicArtists)
                .HasForeignKey(p => p.ArtistId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Music)
                .WithMany(p => p.MusicArtists)
                .HasForeignKey(p => p.MusicId)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
