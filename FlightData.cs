using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class FlightData
    {
        public const string flightFilePath = "C:\\..\\..\\Resources\\res\\flights.csv";

        public static List<Flight> flights = new List<Flight>();

        public FlightData()
        {
            ReadWriteFlightData();
        }

        private void ReadWriteFlightData()
        {
            Flight flight;
            foreach (string line in File.ReadLines(flightFilePath))
            {
                string[] fields = line.Split(',');
                string flightCode = fields[0];
                string flightName = fields[1];
                string originalAirport = fields[2];
                string destinationAirport = fields[3];
                string weekDate = fields[4];
                DateTime time = DateTime.Parse(fields[5]);
                int seats = int.Parse(fields[6]);
                double cost = Double.Parse(fields[7]);

                flight = new Flight(flightCode, flightName, originalAirport, destinationAirport,
                                    weekDate, time, seats, cost);

                flights.Add(flight);
                
            }
        }

        public static List<Flight> MatchFlightData(string originalAirport, string destinationAirport, string weekDate, List<Flight> flights)
        {
            var matchingFlights = new List<Flight>();

            foreach (var flight in flights)
            {
                if (flight.OriginAirport.Equals(originalAirport) && flight.DestinationAirport.Equals(destinationAirport))
                {
                    if (weekDate.Equals("Any") || flight.WeekDate.Equals(weekDate))
                    {
                        matchingFlights.Add(flight);
                    }
                }
            }

            return matchingFlights;
        }

        public static List<Flight> RetrieveFlightData()
        {
            return flights;
        }
    }
}

