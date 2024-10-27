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
            string status = "active";
            Reservation reservation = new Reservation(GenerateResCode(), flight, customerName, citizenship, status);
            List<Reservation> resList = LoadReservations();
            resList.Add(reservation);
            Persist(resList);
            // exception is thrown if: flight is fully booked, flight is null, name is empty/null, citizenship is empty/null
            // create Reservation object and saves to file
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
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Assignment2.Resources.res.reservations.csv";
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            StreamReader reader = new StreamReader(stream);
            List<Reservation> reservationsList = new List<Reservation>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] field = line.Split(",");
                Airport originAirport = Airport.LoadAirportFromCode(field[2]);
                Airport destAirport = Airport.LoadAirportFromCode(field[3]);
                Flight flight = new Flight(field[1], field[2], originAirport, destAirport, field[5], field[6], Convert.ToInt16(field[7]), Convert.ToDouble(field[8]));

                Reservation reservation = new Reservation(field[0], flight, field[9], field[10], (field[11]));
                reservationsList.Add(reservation);
            }     
            return reservationsList;
        }
        //string path = "..\\..\\..\\..\\Resources\\res\\reservations.csv";
        //List<Reservation> list = new List<Reservation>();
        //string[] lines = File.ReadAllLines(path);
        //foreach (string line in lines)
        //{
        //string[] field = line.Split(",");
        //Airport originAirport = Airport.LoadAirportFromCode(field[3]);
        //Airport destAirport = Airport.LoadAirportFromCode(field[4]);
        //Flight flight = new Flight(field[1], field[2], originAirport, destAirport, field[5], field[6], Convert.ToInt16(field[7]), Convert.ToDouble(field[8]));

        //Reservation reservation = new Reservation(field[0], flight, field[10], field[11], (field[12]));
        //list.Add(reservation);
        //    //}
        //    //return list;
        //}
        public static string GenerateResCode()
        {
            Random random = new Random();
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string reservationCode = $"{chars[random.Next(26)]}{random.Next(9)}{random.Next(9)}{random.Next(9)}{random.Next(9)}";
            return reservationCode;
        }


        public static void ModifyReservation(string resCode, string customerName, string citizenship, string status)
        {
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
                    resList.Add (resEntry);
                }
            }
            Persist(resList);
        }

        // saves List of Reservation objs to .csv file  * doesnt currently work *
        public static void Persist(List<Reservation> resList)
        {
            string path = "..\\..\\..\\..\\Resources\\res\\reservations.csv";
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Reservation reservation in resList)
                {
                    sw.WriteLine(reservation);
                }
            }
        }
    }
}
