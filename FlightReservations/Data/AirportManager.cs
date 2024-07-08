using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data
{
    public class AirportManager
    {
        //getting the file path for the csv file
        public const string FILEPATH_airports = @"C:\\Users\\Marian Estrada\\OneDrive\\QA WORK\\Automation Codes\\Assginment2_FlightReservation\\FlightReservations\\Files\\airports.csv";
        //creating a list
        public static List<Airport> airportNames = new List<Airport>();

        public AirportManager()
        {
            PopulateAirportData();
        }

        //reads the lines in the file and splits them at the comma to seperate the different information and stores it in the airportNames list
        private void PopulateAirportData()
        {
            foreach (string line in File.ReadLines(FILEPATH_airports))
            {
                string[] parts = line.Split(',');
                string airportCode = parts[0];
                string airportName = parts[1];
                airportNames.Add(new Airport(airportCode, airportName));
            }

        }


        //returns the airportNames list
        public static List<Airport> GetAirportNames()
        {
            return airportNames;
        }

    }
}
