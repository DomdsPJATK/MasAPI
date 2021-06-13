using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasAPI.Models
{
    public class MatchEfConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(p => new {p.TeamId, p.FieldId, p.MatchId});
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.DateSince).IsRequired();
            builder.Property(p => p.DateUntil).IsRequired();
            builder.Property(p => p.EnemyName).IsRequired().HasMaxLength(30);
        }
    }
}