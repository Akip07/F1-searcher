using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformyProgramistyczneAPI
{
    internal class ExchangeRatesApi
    {
        public HttpClient client = new HttpClient();
        private string key = "849b8a2cc081456aa9e3efb1d942486a";


        public async Task GetData()
        {
            string date = "2010-10-10";
            string call = "https://openexchangerates.org/api/historical/"+date+".json?app_id="+key;
            string response = await client.GetStringAsync(call);
            Console.WriteLine(response);
        }
    }
}
