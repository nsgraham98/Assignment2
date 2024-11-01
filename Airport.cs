using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Airport
    {
        string airportCode; // three letter code
        string airportName;

        public string AirportCode { get => airportCode; set => airportCode = value; }
        public string AirportName { get => airportName; set => airportName = value; }

        public Airport(string airportCode, string airportName)
        {
            this.airportCode = airportCode;
            this.airportName = airportName;
        }

    }
}
