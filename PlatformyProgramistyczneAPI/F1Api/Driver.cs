using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("WebApplication1")]
namespace PlatformyProgramistyczneAPI.F1Api
{
    public class Driver
    {
        public int? driver_number { get; set; }
        public string? broadcast_name { get; set; }
        public string? full_name { get; set; }
        public string? name_acronym { get; set; }
        public string? team_name { get; set; }
        public string? team_colour { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? headshot_url { get; set; }
        public string? country_code { get; set; }
        public int session_key { get; set; }
        public int? meeting_key { get; set; }

        public override string ToString()
        {
            string response = null;
            PropertyInfo[] properties = typeof(Driver).GetProperties();
            foreach (PropertyInfo property in properties)
            {

                response += property.Name + ":\t";
                if (property.GetValue(this) != null)
                    response += property.GetValue(this).ToString() + '\n';
                else
                    response += "---";
                response += "\n";
            }

            return response;
        }
    }
}
