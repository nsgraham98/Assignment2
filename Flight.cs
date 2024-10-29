using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Assignment2
{
    public class Flight
    {
        public string FlightCode { get; set; }
        public string AirlineName { get; set; }
        public Airport OriginAirport { get; set; }
        public Airport DestAirport { get; set; }
        public string WeekDate { get; set; }
        public string Time { get; set; }
        public int Seats { get; set; }
        public double Cost { get; set; }

        public Flight()
        {
            //Flight flight = new Flight();
        }

        public Flight(string flightCode, string airlineName, Airport originAirport, Airport destAirport, string weekDate, string time, int seats, double cost)
        {
            FlightCode = flightCode;
            AirlineName = airlineName;
            OriginAirport = originAirport;
            DestAirport = destAirport;
            WeekDate = weekDate;
            Time = time;
            Seats = seats;
            Cost = cost;
        }

        // returns list of Flight objects that match the input arguments
        public static List<Flight> FindFlights(Airport originAirport, Airport destAirport, string weekDate)
        {
            List<Flight> flightList = LoadFlights();
            List<Flight> foundFlights = new List<Flight>();
            foreach (Flight flight in flightList)
            {
                if (originAirport.AirportCode == flight.OriginAirport.AirportCode & destAirport.AirportCode == flight.DestAirport.AirportCode & (weekDate == flight.WeekDate | weekDate == "Any"))
                {
                    foundFlights.Add(flight);
                }
                //if (destAirport == flight.DestAirport)
                //{
                //    foundFlights.Add(flight);
                //}
                //if (weekDate == flight.WeekDate)
                //{
                //    foundFlights.Add(flight);
                //}
            }
            return foundFlights;
        }


        // loads flights to list from an embedded (properties -> build action -> Embedded Resource) .csv file located in Resources/res/flights.csv
        public static List<Flight> LoadFlights()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, @"Resources\res\flights.csv");
            using (StreamReader reader = new StreamReader(filePath))
            {
                List<Flight> flightsList = new List<Flight>();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] field = line.Split(",");
                    Airport originAirport = Airport.LoadAirportFromCode(field[2]);
                    Airport destAirport = Airport.LoadAirportFromCode(field[3]);
                    Flight flight = new Flight(field[0], field[1], originAirport, destAirport, field[4], field[5], Convert.ToInt16(field[6]), Convert.ToDouble(field[7]));
                    flightsList.Add(flight);
                }
                return flightsList;
            }
        }

        // accepts string flightcode as argument, returns matching Flight object
        public static Flight GetFlightFromCode(string flightcode)
        {
            if (flightcode != null)
            {
                List<Flight> list = LoadFlights();
                foreach (Flight flight in list)
                {
                    if (flightcode == flight.FlightCode)
                    { return flight; }
                }
            }
            else
            {
                Flight noMatchFlightNull = new Flight();
                return noMatchFlightNull;
            }
            Flight noMatchFlight = new Flight();
            return noMatchFlight;
        }

        public override string? ToString()
        {
            return $"{FlightCode},{AirlineName},{OriginAirport.AirportCode},{DestAirport.AirportCode},{WeekDate},{Time},{Seats},{Cost}";
        }
        public static string DisplayFlight(Flight f)
        {
            return $"Code: {f.FlightCode}, Airline: {f.AirlineName}, Departure: {f.OriginAirport.AirportCode}, Destination: {f.DestAirport.AirportCode}, Day: {f.WeekDate}, Time: {f.Time}, Seats: {f.Seats}, Price: ${f.Cost}";
        }
    }
}
