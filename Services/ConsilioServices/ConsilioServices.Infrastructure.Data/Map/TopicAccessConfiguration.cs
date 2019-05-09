using ConsilioServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsilioServices.Infrastructure.Data.Map
{
    public class TopicAccessConfiguration: IEntityTypeConfiguration<TopicAccess>
    {
        public void Configure(EntityTypeBuilder<TopicAccess> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);
        }
    }
}
