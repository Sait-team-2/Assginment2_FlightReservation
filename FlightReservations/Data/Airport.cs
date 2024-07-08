using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data
{
    public class Airport
    {
        //Declaring variables 
        private string airportCode;
        private string airportName;

        //The getters and setters 
        public string AirportCode { get => airportCode; set => airportCode = value; }
        public string AirportName { get => airportName; set => airportName = value; }

        //Empty constructor
        public Airport() { }

        //Constructor to pass the values into the variables
        public Airport(string airportCode, string airportName)
        {
            this.airportCode = airportCode;
            this.airportName = airportName;
        }

        //ToString method to return the airport code and airport name
        public override string ToString()
        {
            return "Airport Code: " + airportCode + "\nAirport Name: " + airportName;
        }
    }
}
