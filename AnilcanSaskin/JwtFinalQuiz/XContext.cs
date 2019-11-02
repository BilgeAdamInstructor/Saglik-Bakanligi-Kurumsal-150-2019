using JwtFinalQuiz.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtFinalQuiz
{
    public class XContext : DbContext
    {
        public XContext(DbContextOptions<XContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
