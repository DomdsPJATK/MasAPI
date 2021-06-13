using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasAPI.Models
{
    public class PersonEfConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.PersonId);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Surname).IsRequired().HasMaxLength(30);
            builder.Property(p => p.DateOfBirth).IsRequired();
            builder.HasOne(p => p.Address).WithMany().HasForeignKey(p => p.AddressId);
        }
    }
}