using FlightReservations.Components.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data
{
    public class FlightManager
    {
        string FLIGHT_TXT = "C:\\Users\\Amrit\\source\\repos\\Assginment2_FlightReservation\\FlightReservations\\flights.csv";
        public static List<Flight> Flights = new List<Flight>();

        public FlightManager()
        {
            PopulateFlights();
        }
        public void PopulateFlights()
        {
            try
            {
                Flight flight;
                foreach (string line in File.ReadLines(FLIGHT_TXT))
                {
                    string[] parts = line.Split(",");
                    string flight_code = parts[0];
                    string airline = parts[1];
                    string origin_airport = parts[2];
                    string destination_airport = parts[3];
                    string day = parts[4];
                    string time = parts[5];
                    int num_seats = int.Parse(parts[6]);
                    double cost = double.Parse(parts[7]);

                    flight = new Flight(flight_code, airline, origin_airport, destination_airport, day, time, num_seats, cost);
                    Flights.Add(flight);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static List<Flight> GetFlights()
        {
            return Flights;
        }
        public List<Flight> FindFlights(string origin, string destination, string day)
        {
            origin = origin.ToLower();
            destination = destination.ToLower();
            day = day.ToLower();
            List<Flight> matchingFlights = new List<Flight>();
            foreach (Flight f in Flights)
            {
                if(f.Origin_Airport.ToLower() == origin && f.Destination_Airport.ToLower() == destination && f.Day.ToLower() == day)
                {
                    matchingFlights.Add(f);
                }
            }
            return matchingFlights;
        }
    }
}
