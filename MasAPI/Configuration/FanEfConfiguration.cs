    using MasAPI.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    namespace MasAPI.Configuration
{
    public class FanEfConfiguration : IEntityTypeConfiguration<Fan>
    {
        public void Configure(EntityTypeBuilder<Fan> builder)
        {
            builder.HasKey(p => p.PersonId);
            builder.HasOne(p => p.Person).WithMany().HasForeignKey(p => p.PersonId);

            builder.Property(p => p.FanCardId).IsRequired().HasMaxLength(30);
            builder.Property(p => p.JoinDate).IsRequired();
        }
    }
}