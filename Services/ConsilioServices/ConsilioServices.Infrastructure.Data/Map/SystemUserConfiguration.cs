using ConsilioServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsilioServices.Infrastructure.Data.Map
{
    public class SystemUserConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.HasKey(su => su.Id);

            builder.Property(su => su.Name)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(su => su.LastName)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(su => su.Email)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);

            builder.Property(su => su.Password)
                .IsRequired()
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder.Property(su => su.Status)
                .IsRequired();

            builder.Property(su => su.RegisterDate)
                .IsRequired();

            builder.HasOne(su => su.SystemProfile)
                .WithMany(p => p.SystemUsers)
                .HasForeignKey(su => su.SystemProfileId);

        }
    }
}
