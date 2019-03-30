using ConsilioServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsilioServices.Infrastructure.Data.Map
{
    class SystemProfileMenuAccessConfiguration : IEntityTypeConfiguration<SystemProfileMenuAccess>
    {
        public void Configure(EntityTypeBuilder<SystemProfileMenuAccess> builder)
        {
            builder.HasKey(pma => pma.Id);

            builder.HasOne(pma => pma.MenuAccess)
                .WithMany(ma => ma.SystemProfileMenuAccesses)
                .HasForeignKey(pma => pma.MenuAccessId);

            builder.HasOne(pma => pma.SystemProfile)
                .WithMany(sp => sp.SystemProfileMenuAccesses)
                .HasForeignKey(pma => pma.SystemProfileId);

            builder.Property(pma => pma.Access)
                .IsRequired();
        }
    }
}
