using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistent.Mapping
{
    public class PlayListMapping : IEntityTypeConfiguration<PlayList>
    {
     
        public void Configure(EntityTypeBuilder<PlayList> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(40);
            builder.Property(p => p.Description).HasMaxLength(75);

            builder.HasOne(p => p.User)
                .WithMany(p => p.PlayLists)
                .HasForeignKey(p => p.UserId);

        }
    }
}
