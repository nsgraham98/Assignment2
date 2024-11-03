using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class ReservationManager
    {

        public static string GenerateResCode()
        {
            Random random = new Random();
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string resCode = $"{chars[random.Next(26)]}{random.Next(9)}{random.Next(9)}{random.Next(9)}{random.Next(9)}";
            return resCode;
        }

        public static Reservation MakeReservation(string resCode, FlightData flight, string customerName, string citizenship)
        {
            Reservation reservation = new Reservation();
            reservations.Add(reservation);
            return reservation;
        }

        public static List<Reservation> reservations = new List<Reservation>();

        public static List<Reservation> FetchReservationList()
        {
            return reservations;
        }

        public static List<Reservation> MatchReservation(string resCode, string airlineName, string customerName, List<Reservation> reservations)
        {
            var matchingReservation = new List<Reservation>();
            foreach (var reservation in reservations)
            {
                if (reservation.ResCode.Equals(resCode) || reservation.AirlineName.Equals(airlineName) || reservation.CustomerName.Equals(customerName))
                {
                    matchingReservation.Add(reservation);
                }
            }

            return matchingReservation;
        }

        public static void SaveReservation()
        {
            string filePath = "C:\\..\\..\\Resources\\res\\reservations.dat";
            using (BinaryWriter bw = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                foreach (var reservation in reservations)
                {
                    bw.Write(UTF8Encoding.Default.GetBytes(
                       $"{reservation.ResCode}, {reservation.CustomerName}, {reservation.Citizenship}, {reservation.FlightCode}, {reservation.AirlineName}, {reservation.Cost}, {reservation.Status}"));
                }
            }

        }
    }
}