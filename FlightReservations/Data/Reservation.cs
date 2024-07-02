using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data
{
    public class Reservation
    {
        public Flight SelectedFlight { get; set; }
        public string TravelerName { get; set; }
        public string TravelerCitizen { get; set; }
        public string ReservationCode { get; set; }
        //Parameterized constructor.
        public Reservation (Flight flight, string name, string citizenship)
        {
            SelectedFlight = flight;
            TravelerName = name;
            TravelerCitizen = citizenship;
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
            return $"{SelectedFlight.Flight_Code},{TravelerName},{TravelerCitizen},{ReservationCode}";
        }
    }
}
