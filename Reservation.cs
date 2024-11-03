using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Assignment2
{
    public class Reservation
    {

        public string ReservationCode { get; set; }
        public Flight Flight { get; set; }
        public string Status { get; set; }

        // validates CustomerName setter using NameNullException
        private string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                if (string.IsNullOrEmpty(value)) { throw new NameNullException("Name cannot be empty");}
                else { customerName = value; }
            }
        }

        // validates Citizenship setter using CitizenshipNullException
        private string citizenship;
        public string Citizenship
        {
            get { return citizenship; }
            set
            {
                if (string.IsNullOrEmpty(value)) { throw new CitizenshipNullException("Citizenship cannot be empty"); }
                else { citizenship = value; }
            }
        }

        public Reservation(string reservationCode, Flight flight, string customerName, string citizenship, string status)
        {
            ReservationCode = reservationCode;
            Flight = flight;
            CustomerName = customerName;
            Citizenship = citizenship;
            Status = status;
        }
        public Reservation() 
        {
            Flight = new Flight();
        }

        public override string? ToString()
        {
            return $"{ReservationCode},{Flight.FlightCode},{Flight.AirlineName},{Flight.OriginAirport.AirportCode},{Flight.DestAirport.AirportCode},{Flight.WeekDate},{Flight.Time},{Flight.Seats},{Flight.Cost},{CustomerName},{Citizenship},{Status}";
        }
        public static string DisplayReservation(Reservation r)
        {
            return $"Reservation Code: {r.ReservationCode}, Flight Code: {r.Flight.FlightCode}, Airline: {r.Flight.AirlineName}, Departure: {r.Flight.OriginAirport.AirportCode}, Destination: {r.Flight.DestAirport.AirportCode}, Day: {r.Flight.WeekDate}, Time: {r.Flight.Time}, Seats: {r.Flight.Seats}, Price: {r.Flight.Cost}, Customer Name: {r.CustomerName}, Citizenship: {r.Citizenship}, Status: {r.Status}";
        }
    }
}
