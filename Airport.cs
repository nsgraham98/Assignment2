using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Assignment2
{
    public class Airport
    {
        public string AirportCode { get; set; }
        public string AirportName { get; set; }

        public Airport()
        {
            Airport airport = new Airport();
        }
        public Airport(string airportCode, string airportName)
        {
            AirportCode = airportCode;
            AirportName = airportName;
        }

        public override string? ToString()
        {
            return $"{AirportCode},{AirportName}";
        }
    }
}
