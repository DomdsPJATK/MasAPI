using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasAPI.Models
{
    public class TeamEfConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(p => p.TeamId);
            builder.Property(p => p.Year).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.League).IsRequired();
        }
    }
}