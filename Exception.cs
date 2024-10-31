using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{    
    public class FlightFullException:Exception
    {
        public FlightFullException() { }
        public FlightFullException(string message)
            : base(message) { }
        public FlightFullException(string message, Exception inner) : base(message, inner) { }
    }

    public class FlightNullException : Exception
    {
        public FlightNullException() { }
        public FlightNullException(string message)
            : base(message) { }
        public FlightNullException(string message, Exception inner) : base(message, inner) { }
    }

    public class NameNullException : Exception
    {
        public NameNullException() { }
        public NameNullException(string message)
            : base(message) { }
        public NameNullException(string message, Exception inner) : base(message, inner) { }
    }

    public class CitizenshipNullException : Exception
    {
        public CitizenshipNullException() { }
        public CitizenshipNullException(string message)
            : base(message) { }
        public CitizenshipNullException(string message, Exception inner) : base(message, inner) { }
    }

    public class FlightNotFoundException : Exception
    {
        public FlightNotFoundException() { }
        public FlightNotFoundException(string message)
            : base(message) { }
        public FlightNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
    public class ResNotFoundException : Exception
    {
        public ResNotFoundException() { }
        public ResNotFoundException(string message)
            : base(message) { }
        public ResNotFoundException(string message, Exception inner) : base(message, inner) { }
    }

}
