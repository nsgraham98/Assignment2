using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class ReservationNullException : Exception
    {
        public ReservationNullException() : base("ERROR: The reservation was not valid")
        {

        }

        public ReservationNullException(string reservation) : base("Invalid Reservation:" + reservation)
        {

        }
    }
}
