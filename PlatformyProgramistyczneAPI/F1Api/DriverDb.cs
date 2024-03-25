using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlatformyProgramistyczneAPI.F1Api
{
    internal class DriverDb : Driver
    {
        public int id { get; set; }

        public override string ToString()
        {
            string response = null;
            PropertyInfo[] properties = typeof(DriverDb).GetProperties();
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
