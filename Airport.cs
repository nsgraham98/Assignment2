using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Airport
    {
        
        private string apCode;
        private string apName;

        public string ApCode { get => apCode; set => apCode = value; }
        public string ApName { get => apName; set => apName = value; }
        
        public Airport()
        {

        }
        public Airport(string apCode, string apName)
        {
            this.apCode = apCode;
            this.apName = apName;
        }

        public override string ToString()
        {
            return $"Airport Code:  {apCode}\nAirport Name: {apName}";
        }
    }
}
