﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data
{
    /// <summary>
    /// Manages flight data operations, including loading flights from a CSV file,
    /// searching for flights, and retrieving all flights.
    /// </summary>
    /// <remarks>
    /// The FlightManager class is responsible for initializing the application with flight data
    /// from a predefined CSV file. It provides functionality to search for flights based on
    /// specific criteria and to retrieve all available flights.
    /// </remarks>
    public class FlightManager
    {
        string FLIGHT_TXT = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\..\Files\flights.csv"));
        public static List<Flight> Flights = new List<Flight>();
        
        //Default constructor
        public FlightManager()
        {
            PopulateFlights();
        }
        //PopulateFlights method: Loads in data of flights from flights.csv and creates flight objects. It then loads flight objects into a list of Flights.
        public void PopulateFlights()
        {
            try
            {
                Flight flight;
                //Foreach loop: Reads flights.csv file, splits data "," and loads data into individual variables. Finally creates flight objects and loads it into Flights list.
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
        //GetFlights method: Returns the Flights list.
        public static List<Flight> GetFlights()
        {
            return Flights;
        }

        //FindFlights method: Finds flights according to origin airport, destination airport and day of week. If found, loads it into a list of matchingFlights and returns the list.
        public List<Flight> FindFlights(string? origin, string? destination, string? day)
        {
            origin = origin?.ToLower();
            destination = destination?.ToLower();
            day = day?.ToLower();
            List<Flight> matchingFlights = new List<Flight>();
            //loops through list of Flights objects loaded in from csv and finds flight based on details entered by user.
            foreach (Flight f in Flights)
            {
                bool originMatch = origin == null || f.Origin_Airport.ToLower() == origin;
                bool destinationMatch = destination == null || f.Destination_Airport.ToLower() == destination;
                bool dayMatch = day == null || f.Day.ToLower() == day;

                if (originMatch && destinationMatch && dayMatch)
                {
                    matchingFlights.Add(f);
                }
            }
            return matchingFlights;
        }
    }
}
