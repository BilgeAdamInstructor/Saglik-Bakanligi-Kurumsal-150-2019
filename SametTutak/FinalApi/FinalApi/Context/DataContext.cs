using FinalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalApi.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        DbSet<User> Users { get; set; }
    }
}
