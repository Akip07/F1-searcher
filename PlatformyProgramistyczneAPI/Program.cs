using PlatformyProgramistyczneAPI.F1Api;
using System.Text.Json;

namespace PlatformyProgramistyczneAPI
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //ExchangeRatesApi a = new ExchangeRatesApi();
            //a.GetData().Wait();

            //var a = f.GetSeasonRaces(2024).Result;
            //List<Session> sessions = JsonSerializer.Deserialize<List<Session>>(a);
            //foreach (Session session in sessions)
            //{
            //    Console.WriteLine(session.ToString());
            //}


            //OpenF1Api f = new OpenF1Api();
            //var a = f.GetSessionDrivers(7763).Result;
            //List<Driver> drivers = JsonSerializer.Deserialize<List<Driver>>(a);
            //foreach (Driver driver in drivers)
            //{
            //    Console.WriteLine(driver.last_name);
            //}
            //Console.WriteLine("Version: " + System.Environment.Version.ToString());
            DbManager run = new DbManager();
            run.ReplaceDriversDbBySession(7787);
            run.PrintDrivers();


            
        }
    }
}
