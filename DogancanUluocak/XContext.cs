using JwtExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtExercise
{
    public class XContext : DbContext
    {
        public XContext(DbContextOptions<XContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
