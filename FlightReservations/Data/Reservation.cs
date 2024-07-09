using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data
{
    /// <summary>
    /// Represents a reservation and its associated details.
    /// </summary>
    /// <remarks>
    /// This class is used to store information about a reservation, including the reservation code,
    /// traveler's name, flight details, and reservation status. It serves as a key component
    /// in managing reservations within the system.
    /// </remarks>
    public class Reservation
    {
        //declaring variables
        private string reservationCode;
        private string flightCode;
        private string airline;
        private double cost;
        private string name;
        private string day;
        private string time;
        private string citizenship;
        private string status;
        private Flight flightdata;

        //generation of properties
        public string ReservationCode { get => reservationCode; set => reservationCode = value; }
        public string FlightCode { get => flightCode; set => flightCode = value; }
        public string Airline { get => airline; set => airline = value; }
        public string Day { get => day; set => day = value; }
        public string Time { get => time; set => time = value; }
        public double Cost { get => cost; set => cost = value; }
        public string TravelerName { get => name; set => name = value; }
        public string TravelerCitizen { get => citizenship; set => citizenship = value; }
        public string Status { get => status; set => status = value; }
        public Flight Flight { get => flightdata; set => flightdata = value; }

        //non-Parameterized constructor
        public Reservation() { }

        //parameterized constructor
        public Reservation(string reservationCode, string flightCode, string airline, string day, string time, double cost, string name, string citizenship, string status)
        {
            this.ReservationCode = reservationCode;
            this.FlightCode = flightCode;
            this.Airline = airline;
            this.Day = day;
            this.time = time;
            this.Cost = cost;
            this.TravelerName = name;
            this.TravelerCitizen = citizenship;
            this.Status = status;
        }

        //this constructor is used to store the process to make the reservation
        public Reservation(string name, string citizenship, Flight flight)
        {
            this.ReservationCode = reservationCode;
            this.TravelerName = name;
            this.TravelerCitizen = citizenship;
            this.Flight = flight;
            this.FlightCode = flight.Flight_Code;
            this.Airline = flight.Airline;
            this.Day = flight.Day;
            this.time = flight.Time;
            this.Cost = flight.Cost;
            this.Status = "Active";

            ReservationCode = GenerateCode(flight, name, citizenship);
        }

        //GenerateCode method: Generates a 5 digit reservation code based on flightnumber, passenger name and citizenship.
        // Reservation codes use the following format: (L meaning Letter, D meaning Digit)
        // LDDDD (e.g., I1234)
        private string GenerateCode(Flight flight, string name, string citizenship)
        {
            // Generate hash codes for the name and citizenship substrings
            int nameHashCode = name.Substring(0, Math.Min(3, name.Length)).ToUpper().GetHashCode();
            int citizenshipHashCode = citizenship.Substring(0, Math.Min(1, citizenship.Length)).ToUpper().GetHashCode();

            // Use the absolute value of the hash code to ensure a positive number and then take a portion of it to keep the length manageable
            string travelerNameCode = Math.Abs(nameHashCode).ToString().Substring(0, 3);
            string citizenshipCode = Math.Abs(citizenshipHashCode).ToString().Substring(0, 1);
            string flightCode = flight.Flight_Code.Substring(0, 1).ToUpper();

            return $"{flightCode}{travelerNameCode}{citizenshipCode}";
        }

        //toCSV method: Returns reservation details in CSV format to save to file.
        public string toCSV()
        {
            return $"{ReservationCode}, {FlightCode},{Airline},{Day},{Time},{Cost},{TravelerName},{TravelerCitizen},{Status}";
        }

        public override string ToString()
        {
            return "Reservation Code: " + ReservationCode +
                    "\nFlight Code: " + FlightCode +
                    "\nAirline: " + Airline +
                    "\nCost: " + Cost +
                    "\n Name: " + TravelerName +
                    "\nCitizenship: " + TravelerCitizen +
                    "\n Status: " + Status;
        }
    }
}
