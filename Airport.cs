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

        // loads airports to list from an embedded (properties -> build action -> Embedded Resource) .csv file located in Resources/res/airports.csv
        public static List<Airport> LoadAirports()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, @"Resources\res\airports.csv");
            using (StreamReader reader = new StreamReader(filePath))
            {
                List<Airport> airportsList = new List<Airport>();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] field = line.Split(',');
                    Airport airport = new Airport(field[0], field[1]);
                    airportsList.Add(airport);
                }
                return airportsList;
            }
        }

        // accepts string airportCode as argument, returns matching Airport object
        public static Airport LoadAirportFromCode(string airportCode)
        {
            List<Airport> list = LoadAirports();
            foreach (Airport airport in list)
            {
                if (airport.AirportCode == airportCode)
                {
                    return airport;
                }
            }
            return new Airport(airportCode, "Airport not found");
        }

        public override string? ToString()
        {
            return $"{AirportCode},{AirportName}";
        }
    }
}
