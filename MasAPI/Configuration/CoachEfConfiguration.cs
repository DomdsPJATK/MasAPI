using MasAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasAPI.Configuration
{
    public class CoachEfConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasKey(p => p.PersonId);
            builder.HasOne(p => p.Person).WithMany().HasForeignKey(p => p.PersonId);
            
            builder.Property(p => p.HourlyRate).IsRequired();
            builder.Property(p => p.Category).IsRequired();
        }
    }
}