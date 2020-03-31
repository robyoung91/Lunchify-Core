using Lunchify.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchify.Data.Services
{
    public class LunchifyDbContext : DbContext
    {
        public LunchifyDbContext(DbContextOptions<LunchifyDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Lunch> Lunches { get; set; }
        public DbSet<LunchEvent> LunchEvents { get; set; }

    }
}
