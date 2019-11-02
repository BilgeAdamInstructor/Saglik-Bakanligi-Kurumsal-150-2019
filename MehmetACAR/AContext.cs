using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PREFinalExam1.Models;

namespace PREFinalExam1
{
    public class AContext : DbContext
    {
        public AContext(DbContextOptions<AContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
