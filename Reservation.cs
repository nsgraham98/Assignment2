using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Reservation
    {
        private string resCode;
        private string flightCode;
        private string airlineName;
        private string cost;
        private string customerName;
        private string citizenship;
        private string status;
        private FlightData flight;

        public string ResCode { get => resCode; set => resCode = value; }
        public string FlightCode { get => flightCode; set => flightCode = value; }
        public string AirlineName { get => airlineName; set => airlineName = value; }
        public string Cost { get => cost; set => cost = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string Citizenship { get => citizenship; set => citizenship = value; }
        public string Status { get => status; set => status = value; }
        public FlightData Flight { get => flight; set => flight = value; }

        public Reservation() { }

        public Reservation(string resCode, string flightCode, string airlineName, string cost, string customerName, string citizenship, string status, FlightData flight)
        {
            this.ResCode = resCode;
            this.FlightCode = flightCode;
            this.AirlineName = airlineName;
            this.Cost = cost;
            this.CustomerName = customerName;
            this.Citizenship = citizenship;
            this.Status = status;
            this.Flight = flight;

        }

        //this constructor is used to store the process to make the reservation
        public Reservation(string resCode, string customerName, string citizenship, FlightData flight)
        {
            this.ResCode = resCode;
            this.CustomerName = customerName;
            this.Citizenship = citizenship;
            this.Flight = flight;
        }

        public override string ToString()
        {
           return $"{resCode}, {flightCode}, {airlineName}, {cost}, {customerName}, {citizenship}, {status}";
        }
    }
}
