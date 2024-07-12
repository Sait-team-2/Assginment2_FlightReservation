using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data
{
    /// <summary>
    /// Represents a flight and its associated details.
    /// </summary>
    /// <remarks>
    /// This class is used to store information about a flight, including its code,
    /// departure and arrival times, airline, and status. It serves as a central part
    /// of the flight management system.
    /// </remarks>
    //Flight class: Class for creating Flight objects.

    public class Flight
    {
        public string Flight_Code { get; set; } = string.Empty;
        public string Airline { get; set; } = string.Empty;
        public string Origin_Airport { get; set; } = string.Empty;
        public string Destination_Airport { get; set; } = string.Empty;
        public string Day { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public int Num_Seats { get; set; }
        public double Cost { get; set; }

        public Flight() { }

        public Flight(string flightCode, string airline, string originAirport, string destinationAirport, string day, string time, int numSeats, double cost)
        {
            Flight_Code = flightCode;
            Airline = airline;
            Origin_Airport = originAirport;
            Destination_Airport = destinationAirport;
            Day = day;
            Time = time;
            Num_Seats = numSeats;
            Cost = cost;
        }
    }
}

