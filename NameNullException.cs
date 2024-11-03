using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class NameNullException : Exception
    {
        public NameNullException() : base("ERROR The name is not valid")
        {

        }

        public NameNullException(string customerName) : base("Invalid Name:" + customerName)
        {

        }
    }
}
