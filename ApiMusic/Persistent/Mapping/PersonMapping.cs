using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Persistent.Mapping
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(25).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(25).IsRequired();
            builder.Property(p => p.Country).HasMaxLength(25).IsRequired();
            builder.Property(p => p.Gender).HasMaxLength(1).IsRequired();

            builder.HasOne(p => p.User)
                .WithOne(p => p.Person)
               .HasForeignKey<Person>(p => p.UserID);
        }
    }
}
