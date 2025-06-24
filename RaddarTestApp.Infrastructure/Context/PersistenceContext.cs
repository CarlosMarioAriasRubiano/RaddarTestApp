using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RaddarTestApp.Domain.Entities;

namespace RaddarTestApp.Infrastructure.Context
{
    public class PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : DbContext(options)
    {
        private readonly IConfiguration _config = config;

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DevConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.Entity<Product>();
            modelBuilder.Entity<User>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
