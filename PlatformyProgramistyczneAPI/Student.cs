using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformyProgramistyczneAPI
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Average { get; set; }

        public override string ToString()
        {
            return $"id: {Id}\tname: {Name}\taverage: {Average:0.00}";
        }
    }
}
