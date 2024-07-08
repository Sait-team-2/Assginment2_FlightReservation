using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data
{
    public class AirportManager
    {
        public static readonly string  FILEPATH_airports =  Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\..\Files\airports.csv"));

        //creating a list
        public static List<Airport> airportNames = new List<Airport>();

        public AirportManager()
        {
            PopulateAirportData();
        }

        //reads the lines in the file and splits them at the comma to seperate the different information and stores it in the airportNames list
        private void PopulateAirportData()
        {
            try{
                foreach (string line in File.ReadLines(FILEPATH_airports))
                {
                    string[] parts = line.Split(',');
                    string airportCode = parts[0];
                    string airportName = parts[1];
                    airportNames.Add(new Airport(airportCode, airportName));
                }
            }
            catch(Exception ex) { 
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Inspect ex.StackTrace or log the exception for more details
                }

        }


        //returns the airportNames list
        public static List<Airport> GetAirportNames()
        {
            return airportNames;
        }

    }
}
