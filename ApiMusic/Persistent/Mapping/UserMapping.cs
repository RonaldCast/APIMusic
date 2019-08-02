using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistent.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Email).HasMaxLength(75).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(75).IsRequired();
            builder.HasMany(p => p.PlayLists)
                .WithOne(p => p.User).HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
