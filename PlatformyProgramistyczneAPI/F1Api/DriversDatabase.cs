using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformyProgramistyczneAPI.F1Api
{
    internal class DriversDatabase : DbContext
    {
        public DbSet<DriverDb> Drivers { get; set; }
        public DriversDatabase() 
        { 
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=Drivers.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DriverDb>().HasData(
                new DriverDb() { id = 1,
                    driver_number = 7,
                    broadcast_name = "F GRZYWACZ",
                    full_name = "Filip Grzywacz",
                    name_acronym = "GRZ",
                    team_name = "Ferrari",
                    team_colour = "F91536",
                    first_name = "Filip",
                    last_name = "Grzywacz",
                    headshot_url = "https://ecsmedia.pl/c/niepowstrzymany-w-iext132429663.jpg",
                    country_code = "PL",
                    session_key = 9158,
                    meeting_key = 1219,
                }
                );
        }
    }
}
