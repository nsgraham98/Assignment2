using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class FlightFullException : Exception
    {
        public FlightFullException() : base("Invalid: There are no more seat available, the flight is currently full.")
        { }

        public FlightFullException(string Seats) : base("Invalid Number of seats available:" + Seats)
        { }
    }
}
