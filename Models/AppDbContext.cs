using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Demo_1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> AppDbContextOptions) : base(AppDbContextOptions)
        { 
        
        }

        public DbSet<PlayerInfo> Players { get; set; }        

    }
}
