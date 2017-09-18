using Microsoft.EntityFrameworkCore;

namespace GithubTrendingVisualizer.Data.Models
{
    public class Context : DbContext
    {
        public DbSet<Repository> Repository { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Repository>()
                .HasAlternateKey(c => c.GithubId)
                .HasName("UniqueKey_GithubId");
        }
    }
}