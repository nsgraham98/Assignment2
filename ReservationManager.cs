using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class ReservationManager
    {
        //put the methods here as needed
        //llist of flights objects
        //make objects and add them to list
        // use using?? for accessing file
        string filePathFlights = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\res\\flights.csv");
        string filePathAirports = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\res\\airports.csv");


        public static List<Flight> flights = new List<Flight>();
        public static List<Flight> searchflights = new List<Flight>();
        public static List<Airport> airports = new List<Airport>();
        public static List<string> dayOfWeek = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        List<Flight> searchFlights = new List<Flight>();

        public ReservationManager()
        {
            populateFlights();
            populateAirport();
        }

        public void populateFlights()
        {
            Flight flight; // do i need this line??

            foreach (string line in File.ReadAllLines(filePathFlights))
            {
                string[] fields = line.Split(',');
                string flightCode = fields[0];
                string airlineName = fields[1];
                string originAirport = fields[2];
                string destinationAirport = fields[3];
                string weekDate = fields[4];
                DateTime time = DateTime.Parse(fields[5]);
                int seats = int.Parse(fields[6]);
                double cost = double.Parse(fields[7]);

                flight = new Flight(flightCode, airlineName, originAirport, destinationAirport, weekDate, time, seats, cost);
                flights.Add(flight);
            }
        }

        private void populateAirport()
        {
            Airport airport;

            foreach (string line in File.ReadAllLines(filePathAirports))
            {
                string[] fields = line.Split(",");
                string airportCode = fields[0];
                string airportName = fields[1];

                airport = new Airport(airportCode, airportName);
                airports.Add(airport);
            }
        }

        public static List<Airport> getAirports()
        {
            return airports;
        }

        public static List<Flight> getFlights()
        { 
            return searchflights;
        }
        public static List<Flight> getFlights(string selectedOriginAirport, string selectedDestinationAirport, string selectedDay) // method to get list of flight
        {
            //takes origin airport, destination airport, day of the week
            //search needs all 3, minimum of 1
            //control list is empty, make update to list when search happens
            //start search by matching origin airport, then destination airport, then day
            // add matching flight to the list made in the beginning

            List<Flight> searchflights = new List<Flight>();
            foreach (Flight flight in searchflights)
            {
                if (flight.OriginAirport == selectedOriginAirport)
                {
                    if (flight.DestinationAirport == selectedDestinationAirport)
                    {
                        if (flight.WeekDate == selectedDay)
                        {
                            searchflights.Add(flight);
                        }
                    }
                }
            }
            return searchflights;
        }
    }

}
