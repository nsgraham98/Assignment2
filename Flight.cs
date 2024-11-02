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

        public override string? ToString()
        {
            return $"{FlightCode},{AirlineName},{OriginAirport.AirportCode},{DestAirport.AirportCode},{WeekDate},{Time},{Seats},{Cost}";
        }
    }
}
