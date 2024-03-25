using PlatformyProgramistyczneAPI.F1Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformyProgramistyczneAPI
{
    internal class Run
    {
        private DriversDatabase driversDatabase;
        public Run()
        {

            driversDatabase = new DriversDatabase();
        }
        private void AddToDatabase(int driver_number = 0,string broadcast_name = "test",string full_name = "test",string name_acronym = "test",string team_name = "test",string team_colour = "test",string first_name = "test",string last_name = "test",string headshot_url = "test",string country_code = "test",int session_key = 1,int meeting_key = 1)
        {
            driversDatabase.Drivers.Add(new DriverDb()
            {
                driver_number = driver_number,
                broadcast_name = broadcast_name,
                full_name = full_name,
                name_acronym = name_acronym,
                team_name = team_name,
                team_colour = team_colour,
                first_name = first_name,
                last_name = last_name,
                headshot_url = headshot_url,
                country_code = country_code,
                session_key = session_key,
                meeting_key = meeting_key,

            });
            driversDatabase.SaveChanges();
        }
        private void ClearDatabase()
        {
            driversDatabase.Drivers.RemoveRange(driversDatabase.Drivers);
            driversDatabase.SaveChanges(true);
        }

        private List<DriverDb> GetDriversFromTeam(string team_name)
        {
            List<DriverDb> drivers = driversDatabase.Drivers.Where(d => d.team_name == team_name).ToList<DriverDb>();
            return drivers;
           
        }

        private void RemoveDriver(int id)
        {
            var driver = driversDatabase.Drivers.First(d => d.id == id);
            driversDatabase.Drivers.Remove(driver);
            driversDatabase.SaveChanges();
        }

        public void RunProgram()
        {

            //AddToDatabase();
            List<DriverDb> drivers = driversDatabase.Drivers.ToList<DriverDb>();
            //List<DriverDb> ferrariDrivers = GetDriversFromTeam("Ferrari");
            //RemoveDriver(7);
            foreach (DriverDb driver in drivers)
            {
                Console.WriteLine(driver.ToString());
            }


        }
    }
}
