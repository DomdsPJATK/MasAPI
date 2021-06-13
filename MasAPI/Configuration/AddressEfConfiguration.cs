using MasAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasAPI.Configuration
{
    public class AddressEfConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.AddressId);
            builder.Property(p => p.City).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Street).IsRequired().HasMaxLength(30);
            builder.Property(p => p.PostalCode).IsRequired().HasMaxLength(6);
            builder.Property(p => p.StreetNumber).IsRequired();
        }
    }
}