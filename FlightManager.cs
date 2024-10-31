using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public abstract class FlightManager
    {
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
                    Airport originAirport = AirportManager.LoadAirportFromCode(field[2]);
                    Airport destAirport = AirportManager.LoadAirportFromCode(field[3]);
                    Flight flight = new Flight(field[0], field[1], originAirport, destAirport, field[4], field[5], Convert.ToInt16(field[6]), Convert.ToDouble(field[7]));
                    flightsList.Add(flight);
                }
                return flightsList;
            }
        }

        // returns list of Flight objects that match the input arguments
        public static List<Flight> FindFlights(Airport originAirport, Airport destAirport, string weekDate)
        {
            List<Flight> flightList = LoadFlights();
            List<Flight> foundFlights = new List<Flight>();
            foreach (Flight flight in flightList)
            {
                if (originAirport.AirportCode == flight.OriginAirport.AirportCode && destAirport.AirportCode == flight.DestAirport.AirportCode & (weekDate == flight.WeekDate || weekDate == "Any"))
                {
                    foundFlights.Add(flight);
                }
            }
            return foundFlights;
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
                throw new FlightNotFoundException("Flight not found.");
            }
            throw new FlightNotFoundException("Flight not found.");
        }
        public static void Persist(List<Flight> flightList)
        {
            // Build path relative to the project's base directory
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, @"Resources\res\flight.csv");

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (Flight flightEntry in flightList)
                {
                    sw.WriteLine(flightEntry.ToString());
                }
            }
        }
        public static string DisplayFlight(Flight f)
        {
            return $"Code: {f.FlightCode}, Airline: {f.AirlineName}, Departure: {f.OriginAirport.AirportCode}, Destination: {f.DestAirport.AirportCode}, Day: {f.WeekDate}, Time: {f.Time}, Seats: {f.Seats}, Price: ${f.Cost}";
        }

        public static int GetFlightSeats(Flight flight)
        {
            int seats = flight.Seats;
            List<Reservation> resList = ReservationManager.LoadReservations();
            foreach (Reservation reservation in resList)
            {
                if ((reservation.Flight == flight) && (reservation.Status == "active"))
                {
                    seats--;
                }
            }
            return seats;
        }
    }
}
