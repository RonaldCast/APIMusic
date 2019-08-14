using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistent.Mapping
{
    public class PlayListMusicMapping : IEntityTypeConfiguration<PlayListMusic>
    {
        public void Configure(EntityTypeBuilder<PlayListMusic> builder)
        {

            builder.HasKey(k => new {k.MusicId, k.PlayListId });

            builder.HasOne(p => p.PlayList)
                .WithMany(p => p.PlayListMusics)
                .HasForeignKey(p => p.PlayListId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Music)
                .WithMany(p => p.PlayListMusics)
                .HasForeignKey(p => p.MusicId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
