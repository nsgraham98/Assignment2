using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Blazorise.Extensions;


namespace Assignment2
{
    public abstract class ReservationManager
    {
        // Creates Reservation obj using input arguments, saves to .csv file

        // checks available seats and flightcode format -> throws Exceptions
        // uses GenerateResCode to randomly generate Reservation Code
        // creates Reservation object using input parameters and Reservation Code
        // loads all Reservations to List<Reservation> using LoadReservations()
        // adds created Reservation object to List
        // Saves List to reservations.csv using Persist(resList)
        public static void MakeReservation(Flight flight, string customerName, string citizenship)
        {
            if (FlightManager.GetFlightSeats(flight) <= 0)
            {
                throw new FlightFullException("Sorry, this flight is full");
            }
            if (string.IsNullOrEmpty(flight.FlightCode))
            {
                throw new FlightNullException("No flight selected");
            }

            string status = "active";
            Reservation reservation = new Reservation(GenerateResCode(), flight, customerName, citizenship, status);
            List<Reservation> resList = LoadReservations();
            resList.Add(reservation);
            Persist(resList);
        }

        // finds all Reservations that corresponds to input parameters -> returns List<Reservation> of all found Reservations

        // loads all Reservations to List<Reservation> using LoadReservations()
        // creates new empty List<Reservation> for found reservations
        // if every parameter is null or empty, returns List of every reservation
        // otherwise, iterates through list of all reservations
        // adds any reservation to foundResList that matches search criteria
        // returns foundResList
        public static List<Reservation> FindReservation(string reservationCode, string airline, string customerName)
        {
            List<Reservation> resList = LoadReservations();
            List<Reservation> foundResList = new List<Reservation>();

            if (string.IsNullOrEmpty(reservationCode) && string.IsNullOrEmpty(airline) && string.IsNullOrEmpty(customerName))
            {
                return resList;
            }

            foreach (Reservation res in resList)
            {
                if (reservationCode == res.ReservationCode)
                {
                    foundResList.Add(res);
                    continue;
                }
                if (airline == res.Flight.AirlineName)
                {
                    foundResList.Add(res);
                    continue;
                }
                if (customerName == res.CustomerName)
                {
                    foundResList.Add(res);
                    continue;
                }
            }
            return foundResList;
        }

        // loads reservations to list from a .csv file located in Resources/res/reservations.csv

        // Loop: Reads .csv line -> constructs Reservation Object -> adds Object to List<Reservation> reservationsList -> repeat loop
        // returns List<Reservation> reservationsList
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
                    Airport originAirport = AirportManager.LoadAirportFromCode(field[3]);
                    Airport destAirport = AirportManager.LoadAirportFromCode(field[4]);
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

        // randomly generates reservationCode (L####)
        // returns reservationCode 
        public static string GenerateResCode()
        {
            Random random = new Random();
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string reservationCode = $"{chars[random.Next(26)]}{random.Next(9)}{random.Next(9)}{random.Next(9)}{random.Next(9)}";
            return reservationCode;
        }

        // finds Reservation corresponding to inputted reservationCode -> modifies Reservation -> saves back to reservations.csv

        // loads all Reservations to List<Reservation> using LoadReservations()
        // iterates through resList until Reservation object with corresponding reservationCode is found
        // Reservation object is removed from list
        // validates and sets attributes for found Reservation according to user inputted parameters 
        // Adds Reservation object back to List
        // saves List to reservations.csv using Persist(resList)
        public static void ModifyReservation(string resCode, string customerName, string citizenship, string status)
        {
            bool found = false;

            List<Reservation> resList = LoadReservations();
            foreach (Reservation resEntry in resList)
            {
                if (resCode == resEntry.ReservationCode & !found)
                {
                    resList.Remove(resEntry);
                    if (customerName != resEntry.CustomerName)
                    {
                        resEntry.CustomerName = customerName;
                    }

                    if (status != resEntry.Status)
                    {
                        if (status == "active")
                        {
                            int seats = FlightManager.GetFlightSeats(resEntry.Flight);
                            if (seats <= 0)
                            {
                                throw new FlightFullException("Sorry, this flight is full.");
                            }
                        }
                        resEntry.Status = status;
                    }

                    if (citizenship != resEntry.Citizenship)
                    {
                        resEntry.Citizenship = citizenship;
                    }
                    resList.Add(resEntry);
                    found = true;
                    Persist(resList);
                    break;
                }          
            }
            if (!found)
            {
                throw new ResNotFoundException("Reservation not found");
            }
        }

        // requires List<Reservation> of all reservation objects to save to .csv file

        // Builds path relative to the project's base directory
        // gets file path for reservations.csv
        // Loop: uses StreamWriter to write resEntry.ToString() to file -> repeat loop
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

