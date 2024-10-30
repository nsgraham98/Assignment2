using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Flight
    {
        private string flightCode;
        private string airlineName;
        private string originAirport;
        private string destinationAirport;
        private string weekDate;
        private DateTime time;
        private int seats;
        private double cost;

        public string FlightCode { get => flightCode; set => flightCode = value; }
        public string AirlineName { get => airlineName; set => airlineName = value; }
        public string OriginAirport { get => originAirport; set => originAirport = value; }
        public string DestinationAirport { get => destinationAirport; set => destinationAirport = value; }
        public string WeekDate { get => weekDate; set => weekDate = value; }
        public DateTime Time { get => time; set => time = value; }
        public int Seats { get => seats; set => seats = value; }
        public double Cost { get => cost; set => cost = value; }

        public Flight(string flightCode, string airlineName, string originAirport, string destinationAirport, string weekDate, DateTime time, int seats, double cost)
        {
            this.FlightCode = flightCode;
            this.AirlineName = airlineName;
            this.OriginAirport = originAirport;
            this.DestinationAirport = destinationAirport;
            this.WeekDate = weekDate;
            this.Time = time;
            this.Seats = seats;
            this.Cost = cost;
        }

    }
}
