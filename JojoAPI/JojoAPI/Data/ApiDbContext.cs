using JojoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace JojoAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Stand> Stands { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                        .Property(x => x.Role)
                        .HasConversion<string>();
        }
    }
}
