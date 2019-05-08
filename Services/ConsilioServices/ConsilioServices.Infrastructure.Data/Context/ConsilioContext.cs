using ConsilioServices.Domain.Entities;
using ConsilioServices.Infrastructure.Data.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.IO;
using System.Linq;

namespace ConsilioServices.Infrastructure.Data.Context
{
    public class ConsilioContext : DbContext
    {
        public static readonly LoggerFactory loggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<SystemProfile> SystemProfiles { get; set; }
        public DbSet<MenuAccess> MenuAccesses { get; set; }
        public DbSet<SystemProfileMenuAccess> SystemProfileMenuAccesses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .UseSqlServer(config.GetConnectionString("DBConsilio"));            
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
            modelBuilder.ApplyConfiguration(new MenuAccessConfiguration());
            modelBuilder.ApplyConfiguration(new SystemProfileMenuAccessConfiguration());
        }
    }
}
