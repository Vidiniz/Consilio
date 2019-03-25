using ConsilioServices.Domain.Entities;
using ConsilioServices.Infrastructure.Data.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace ConsilioServices.Infrastructure.Data.Context
{
    public class ConsilioContext : DbContext
    {
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<SystemProfile> SystemProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DBConsilio"));            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SystemUserConfiguration());
            modelBuilder.ApplyConfiguration(new SystemProfileConfiguration());
        }
    }
}
