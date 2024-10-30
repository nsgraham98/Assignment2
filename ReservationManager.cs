using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;


namespace Assignment2
{
    public abstract class ReservationManager
    {
        // Creates Reservation obj using input arguments, adds to List of all Reservation objs, passes List to Persist() which saves Reservation List to reservations.csv
        public static void MakeReservation(Flight flight, string customerName, string citizenship)
        {
            if (flight.Seats <= 0)
            {
                throw new FlightFullException("Sorry, this flight is full.");
            }
            if (string.IsNullOrEmpty(flight.FlightCode))
            {
                throw new FlightNullException("No flight selected.");
            }
            if (string.IsNullOrEmpty(customerName))
            {
                throw new NameNullException("Name cannot be empty.");
            }
            if (string.IsNullOrEmpty(citizenship))
            {
                throw new CitizenshipNullException("Citizenship cannot be empty.");
            }

            string status = "active";
            Reservation reservation = new Reservation(GenerateResCode(), flight, customerName, citizenship, status);
            List<Reservation> resList = LoadReservations();
            resList.Add(reservation);
            Persist(resList);
        }

        // loads all Reservation objs using LoadReservations(), checks if input arguments match existing Reservation obj, returns List of Reservation obj
        public static List<Reservation> FindReservation(string reservationCode, string airline, string customerName)
        {
            List<Reservation> resList = LoadReservations();
            List<Reservation> foundResList = new List<Reservation>();
            foreach (Reservation res in resList)
            {
                if (reservationCode == res.ReservationCode)
                {
                    foundResList.Add(res);
                }
                if (airline == res.Flight.AirlineName)
                {
                    foundResList.Add(res);
                }
                if (customerName == res.CustomerName)
                {
                    foundResList.Add(res);
                }
            }
            return foundResList;
            // if all args are empty it returns every reservation
        }

        // needs mutator/setter to modify reservation mobjects


        // loads reservations to list from .csv file located in Resources/res/reservations.csv
        public static List<Reservation> LoadReservations()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, @"Resources\res\reservations.csv");
            using (StreamReader reader = new StreamReader(filePath))
            {
                List<Reservation> reservationsList = new List<Reservation>();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] field = line.Split(",");

                    string reservationCode = field[0];
                    string flightCode = field[1];
                    string airlineName = field[2];
                    Airport originAirport = Airport.LoadAirportFromCode(field[3]);
                    Airport destAirport = Airport.LoadAirportFromCode(field[4]);
                    string weekDate = field[5];
                    string time = field[6];
                    int seats = Convert.ToInt16(field[7]);
                    double cost = Convert.ToDouble(field[8]);

                    Flight flight = new Flight(flightCode, airlineName, originAirport, destAirport, weekDate, time, seats, cost);

                    string customerName = field[9];
                    string citizenship = field[10];
                    string status = field[11];
                  
                    Reservation reservation = new Reservation(reservationCode, flight, customerName, citizenship, status);

                    reservationsList.Add(reservation);
                }
                return reservationsList;
            }
        }

        public static string GenerateResCode()
        {
            Random random = new Random();
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string reservationCode = $"{chars[random.Next(26)]}{random.Next(9)}{random.Next(9)}{random.Next(9)}{random.Next(9)}";
            return reservationCode;
        }


        public static void ModifyReservation(string resCode, string customerName, string citizenship, string status)
        {           
            if (string.IsNullOrEmpty(customerName))
            {
                throw new NameNullException("Name cannot be empty.");
            }
            if (string.IsNullOrEmpty(citizenship))
            {
                throw new CitizenshipNullException("Citizenship cannot be empty.");
            }

            List<Reservation> resList = LoadReservations();
            foreach (Reservation resEntry in resList)
            {
                if (resCode == resEntry.ReservationCode)
                {
                    resList.Remove(resEntry);
                    if (customerName != resEntry.CustomerName)
                    {
                        resEntry.CustomerName = customerName;
                    }
                    if (status != resEntry.Status)
                    {
                        resEntry.Status = status;
                    }
                    if (citizenship != resEntry.Citizenship)
                    {
                        resEntry.Citizenship = citizenship;
                    }
                    resList.Add(resEntry);
                    Persist(resList);
                    break;
                }
            }
        }

        // saves List of Reservation objs to .csv file  * doesnt currently work *
        public static void Persist(List<Reservation> resList)
        {
            // Build path relative to the project's base directory
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, @"Resources\res\reservations.csv");

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (Reservation resEntry in resList)
                {
                    sw.WriteLine(resEntry.ToString());
                }
            }
        }
    }
}
