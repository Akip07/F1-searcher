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
    public class SessionDb : Session
    {
        public int id {  get; set; }

        public override string ToString()
        {
            string response = null;
            PropertyInfo[] properties = typeof(SessionDb).GetProperties();
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
