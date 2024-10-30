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
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\res\\flights.csv");

        public static List<Flight> flights = new List<Flight>();

        public ReservationManager() 
        {
            populateFlights();
        }

        private void populateFlights()
        {
            Flight flight; // do i need this line??

            foreach (string line in File.ReadAllLines(filePath))
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

        public static List<Flight> getFlights() // method to get list of flight
            { 
                return flights; 
            }
    }            

}
