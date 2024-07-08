using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data
{
    public class Reservation
    {
        //declaring variables
        private string reservationCode;
        private string flightCode;
        private string airline;
        private int cost;
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
        public int Cost { get => cost; set => cost = value; }
        public string TravelerName { get => name; set => name = value; }
        public string TravelerCitizen { get => citizenship; set => citizenship = value; }
        public string Status { get => status; set => status = value; }
        public Flight Flight { get => flightdata; set => flightdata = value; }

        //non-Parameterized constructor
        public Reservation() { }

        //parameterized constructor
        public Reservation(string reservationCode, string flightCode, string airline, string day, string time, int cost, string name, string citizenship, string status)
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
        public Reservation(string reservationCode, string name, string citizenship, Flight flight)
        {
            this.ReservationCode = reservationCode;
            this.TravelerName = name;
            this.TravelerCitizen = citizenship;
            this.Flight = flight;

            ReservationCode = GenerateCode(flight, name, citizenship);
        }

        //GenerateCode method: Generates a 9 digit reservation code based on flightnumber, passenger name and citizenship.
        private string GenerateCode(Flight flight, string name, string citizenship)
        {
            string flightCode = flight.Flight_Code.Substring(0, 3).ToUpper();
            string travelerNameCode = name.Substring(0, 3).ToUpper();
            string citizenshipCode = citizenship.Substring(0, 3).ToUpper();
            return $"{flightCode}{travelerNameCode}-{citizenshipCode}";
        }

        //toCSV method: Returns reservation details in CSV format to save to file.
        public string toCSV()
        {
            return $"{Flight.Flight_Code},{TravelerName},{TravelerCitizen},{ReservationCode}";
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
