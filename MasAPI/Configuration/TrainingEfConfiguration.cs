using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasAPI.Models
{
    public class TrainingEfConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.HasKey(p => new {p.TrainingId, p.TeamId, p.FieldId});
            builder.Property(p => p.DateSince).IsRequired();
            builder.Property(p => p.DateUntil).IsRequired();
        }
    }
}