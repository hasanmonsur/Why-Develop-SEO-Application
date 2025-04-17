using Microsoft.EntityFrameworkCore;
using SeoBlog.Models;

namespace SeoBlog.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey(p => p.Id);
        }
    }
}
