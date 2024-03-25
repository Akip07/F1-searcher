using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

[assembly: InternalsVisibleTo("WebApplication3")]
namespace PlatformyProgramistyczneAPI.F1Api
{
    internal class OpenF1Api
    {
        public HttpClient client = new HttpClient();
        private string apiUrl = "https://api.openf1.org/v1";



        public async Task<List<Session>> GetSeasonRaces(int year)
        {
            string call = apiUrl + $"/sessions?year={year}" + "&session_name=Race";
            string response = await client.GetStringAsync(call);
            List<Session> sessions = JsonSerializer.Deserialize<List<Session>>(response);
            return sessions;

        }



        public async Task<List<Driver>> GetSessionDrivers(int session_key)
        {
            string call = apiUrl + $"/drivers?session_key={session_key}";
            string response = await client.GetStringAsync(call);
            
            List<Driver> drivers = JsonSerializer.Deserialize<List<Driver>>(response);
            return drivers;
        }
    }
}
