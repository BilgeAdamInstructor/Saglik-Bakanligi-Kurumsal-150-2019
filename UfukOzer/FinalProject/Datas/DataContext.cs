using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Datas
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        DbSet<User> Users { get; set; }
    }
}
