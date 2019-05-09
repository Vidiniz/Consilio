using ConsilioServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsilioServices.Infrastructure.Data.Map
{
    public class MenuAccessConfiguration: IEntityTypeConfiguration<MenuAccess>
    {
        public void Configure(EntityTypeBuilder<MenuAccess> builder)
        {
            builder.HasKey(ma => ma.Id);

            builder.Property(ma => ma.Name)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.HasOne(ma => ma.TopicAccess)
                .WithMany(ta => ta.MenuAccesses)
                .HasForeignKey(ma => ma.TopicAccessId);
        }
    }
}
