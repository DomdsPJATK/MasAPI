using MasAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasAPI.Configuration
{
    public class PlayerEfConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.PersonId);
            builder.HasOne(p => p.Person).WithMany().HasForeignKey(p => p.PersonId);

            builder.Property(p => p.Weight).IsRequired();
            builder.Property(p => p.BetterLeg).IsRequired();
        }
    }
}