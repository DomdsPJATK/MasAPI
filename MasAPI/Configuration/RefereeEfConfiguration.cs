using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasAPI.Models
{
    public class RefereeEfConfiguration : IEntityTypeConfiguration<Referee>
    {
        public void Configure(EntityTypeBuilder<Referee> builder)
        {
            builder.HasKey(p => p.PersonId);
            builder.HasOne(p => p.Person).WithMany().HasForeignKey(p => p.PersonId);

            builder.Property(p => p.IdNumber).IsRequired().HasMaxLength(20);
        }
    }
}