using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasAPI.Models
{
    public class FieldEfConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.HasKey(p => p.FieldId);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.SeatQuantity).IsRequired();
        }
    }
}