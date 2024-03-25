using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace PlatformyProgramistyczneAPI.F1Api
{
    internal class OpenF1Api
    {
        public HttpClient client = new HttpClient();
        private string apiUrl = "https://api.openf1.org/v1";

        public async Task<string> GetSeasonRaces(int year)
        {
            string call = apiUrl + $"/sessions?year={year}" + "&session_name=Race";
            string response = await client.GetStringAsync(call);
            return response;
        }

        public async Task<string> GetSessionDrivers(int session_key)
        {
            string call = apiUrl + $"/drivers?session_key={session_key}";
            string response = await client.GetStringAsync(call);
            return response;
        }
    }
}
