using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data
{
    /// <summary>
    /// Represents an airport with a unique code and name.
    /// This class is part of the flight reservation system and is used to manage airport-related information.
    /// </summary>
    public class Airport
    {
        public string AirportCode { get; set; } = string.Empty;
        public string AirportName { get; set; } = string.Empty;
        public Airport() { }
        public Airport(string airportCode, string airportName)
        {
            AirportCode = airportCode;
            AirportName = airportName;
        }
    }
}

