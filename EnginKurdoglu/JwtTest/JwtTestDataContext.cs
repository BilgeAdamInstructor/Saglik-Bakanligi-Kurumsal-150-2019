using JwtTest.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtTest
{
    public class JwtTestDataContext : DbContext
    {
        public JwtTestDataContext(DbContextOptions<JwtTestDataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
