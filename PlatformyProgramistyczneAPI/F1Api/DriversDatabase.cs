using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("WebApplication3")]
namespace PlatformyProgramistyczneAPI.F1Api
{
    internal class DriversDatabase : DbContext
    {
        public DbSet<DriverDb> Drivers { get; set; }
        public DbSet<SessionDb> Sessions { get; set; }
        public DriversDatabase() 
        { 
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=Drivers.db");
            options.UseSqlite(@"Data Source=Sessions.db");
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

            modelBuilder.Entity<SessionDb>().HasData(
                new SessionDb()
                {
                    id = 1,
                    session_key = 1,
                    session_name = "test",
                    date_start = DateTime.Now,
                    date_end = DateTime.Now,
                    gmt_offset = "test",
                    session_type = "test",
                    meeting_key = 1,
                    location = "test",
                    country_key = 1,
                    country_code = "test",
                    country_name = "test",
                    circuit_key = 1,
                    circuit_short_name = "test",
                    year = 1,
                }
                );
        }
    }
}
