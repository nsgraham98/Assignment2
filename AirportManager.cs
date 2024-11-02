using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public abstract class AirportManager
    {
        // loads airports to list from a .csv file located in Resources/res/airports.csv
        // Loop: Reads .csv line -> constructs Airport Object -> adds Object to List<Airport> airportsList -> repeat loop
        // returns List<Airport> airportsList
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

                    string airportCode = field[0];
                    string airportName = field[1];

                    Airport airport = new Airport(airportCode, airportName);
                    airportsList.Add(airport);
                }
                return airportsList;
            }
        }
        // requires string airportCode as parameter, returns matching Airport object
        // uses LoadAirports() to create list of all airports
        // iterates through list until airportCode parameter matches airport Object
        // returns Airport Object airport
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

    }
}
