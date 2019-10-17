using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BrightHouseLast.Models;

namespace BrightHouseLast.Models
{
    public class BrightHouseLastContext : DbContext
    {
        public BrightHouseLastContext (DbContextOptions<BrightHouseLastContext> options)
            : base(options)
        {
        }

        public DbSet<BrightHouseLast.Models.Orders> Orders { get; set; }

        public DbSet<BrightHouseLast.Models.People> People { get; set; }

        public DbSet<BrightHouseLast.Models.Returns> Returns { get; set; }
    }
}
