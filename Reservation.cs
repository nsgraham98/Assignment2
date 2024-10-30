using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Reservation
    {
        private string reservationCode;
        private string flightCode;
        private string airlineName;
        private double cost;
        private string name; // customer name
        private string citizenship;
        private bool status; // active or inactive

        public string ReservationCode { get => reservationCode; set => reservationCode = value; }
        public string FlightCode { get => flightCode; set => flightCode = value; }
        public string AirlineName { get => airlineName; set => airlineName = value; }
        public double Cost { get => cost; set => cost = value; }
        public string Name { get => name; set => name = value; }
        public string Citizenship { get => citizenship; set => citizenship = value; }
        public bool Status { get => status; set => status = value; }

        public Reservation(string reservationCode, string flightCode, string airlineName, double cost, string name, string citizenship, bool status)
        {
            this.reservationCode = reservationCode;
            this.flightCode = flightCode;
            this.airlineName = airlineName;
            this.cost = cost;
            this.name = name;
            this.citizenship = citizenship;
            this.status = status;
        }
    }
}
