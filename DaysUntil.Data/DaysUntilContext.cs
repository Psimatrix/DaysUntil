using DaysUntil.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysUntil.Data
{
    public class DaysUntilContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO move connection string into configuration file and read from it
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DaysUntil;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
