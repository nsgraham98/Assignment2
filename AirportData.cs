using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class AirportData
    {
        public const string apFilePath = "C:\\..\\..\\Resources\\res\\airports.csv";
   
        public static List<Airport> airports = new List<Airport>();

        public AirportData()
        {
            ReadWriteAirportData();
        }

        private void ReadWriteAirportData()
        {
            foreach (string line in File.ReadLines(apFilePath))
            {
                string[] fields = line.Split(',');
                string apCode = fields[0];
                string apName = fields[1];
                airports.Add(new Airport(apCode, apName));
            }

        }

        public static List<Airport> GetAirportNames()
        {
            return airports;
        }
    }
}
