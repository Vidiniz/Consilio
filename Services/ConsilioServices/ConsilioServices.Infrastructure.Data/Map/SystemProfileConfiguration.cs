using ConsilioServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsilioServices.Infrastructure.Data.Map
{
    public class SystemProfileConfiguration : IEntityTypeConfiguration<SystemProfile>
    {
        public void Configure(EntityTypeBuilder<SystemProfile> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(p => p.HasAdmin)
                .IsRequired();

            builder.HasMany(p => p.SystemUsers)
                .WithOne(su => su.SystemProfile)
                .HasForeignKey(su => su.SystemProfileId);
        }
    }
}
