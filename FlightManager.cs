using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public abstract class FlightManager
    {
        // loads flights to list from a .csv file located in Resources/res/flights.csv

        // Loop: Reads .csv line -> constructs Flight Object -> adds Object to List<Flight> flightsList -> repeat loop
        // returns List<Flight> flightsList
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

        // returns list of Flight objects that correspond to input parameters

        // gets List<Flight> of all flights from LoadFlights() function
        // iterates through list, adding any corresponding flight to a new List<Flight> foundFlights
        // returns List<Flight> foundFlights
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

        // gets List<Flight> of all flights from LoadFlights() function
        // iterates through list, until finding corresponding flightCode to Flight.FlightCode
        // returns corresponding Flight flight
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

        // requires List<Flight> of all flight objects to save to .csv file

        // Builds path relative to the project's base directory
        // gets file path for flights.csv
        // Loop: uses StreamWriter to write flightEntry.ToString() to file -> repeat loop
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

        // Readable display of flight attributes for Find Flights Page -> requires Flight object as parameter
        public static string DisplayFlight(Flight f)
        {
            return $"Code: {f.FlightCode}, Airline: {f.AirlineName}, Departure: {f.OriginAirport.AirportCode}, Destination: {f.DestAirport.AirportCode}, Day: {f.WeekDate}, Time: {f.Time}, Seats: {GetFlightSeats(f)}, Price: ${f.Cost}";
        }

        // used to return available seats on a flight

        // requires Flight object as parameter
        // gets List<Reservation> of all reservations from LoadReservations() function
        // iterates through resList and checks if reservation is active and corresponds to the input flight Object
        // decrements seats for every match
        // returns seats

        // done this way to avoid loading all 1000+ flights
        public static int GetFlightSeats(Flight flight)
        {
            int seats = flight.Seats;
            List<Reservation> resList = ReservationManager.LoadReservations();
            foreach (Reservation reservation in resList)
            {
                if ((reservation.Flight.FlightCode == flight.FlightCode) && (reservation.Status == "active"))
                {
                    seats--;
                }
            }
            return seats;
        }
    }
}
