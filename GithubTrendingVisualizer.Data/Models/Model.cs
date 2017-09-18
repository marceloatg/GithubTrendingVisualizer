using Microsoft.EntityFrameworkCore;

namespace GithubTrendingVisualizer.Data.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Repository> Repository { get; set; }
        public DbSet<User> Users { get; set; }
    }
}