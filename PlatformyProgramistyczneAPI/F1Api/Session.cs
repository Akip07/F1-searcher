using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

[assembly: InternalsVisibleTo("WebApplication3")]
namespace PlatformyProgramistyczneAPI.F1Api
{
    internal class Session
    {
        public int session_key { get; set; }
        public string session_name { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_end { get; set; }
        public string gmt_offset { get; set; }
        public string session_type { get; set; }
        public int meeting_key { get; set; }
        public string location { get; set; }
        public int country_key { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public int circuit_key { get; set; }
        public string circuit_short_name { get; set; }
        public int year { get; set; }

        public override string ToString()
        {
            string response = null;
            PropertyInfo[] properties = typeof(Session).GetProperties();
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
