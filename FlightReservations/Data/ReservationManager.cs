using FlightReservations.Components.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data
{ 
    public class ReservationManager
    {
        public List<Flight> flights;

        string airline {get; set;} 
        string travelerName {get; set;}
        string travelerCitizen {get; set;}
        string errorMessage {get; set;}
        string reservationCode  {get; set;}
        string selectedFlightCode {get; set;}

        string RESERVATION_PATH = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\..\Files\reservation.csv"));
        public static List<Reservation> Reservations = new List<Reservation>(); 
       

        public ReservationManager()
        {
            flights = new List<Flight>();
            Reservations = new List<Reservation>();
            PopulateReservations();
        }

        //static method that can be accessed throughout the project
        public static List<Reservation> GetReservations()
        {
            return Reservations;
        }

        public void PopulateReservations()
        {
            try
            {
                Reservation reservationlist;
                //Foreach loop: Reads flights.csv file, splits data "," and loads data into individual variables. Finally creates flight objects and loads it into Flights list.
                foreach (string line in File.ReadLines(RESERVATION_PATH))
                {
                    string[] parts = line.Split(",");
                    string reservationCode = parts[0];
                    string flightCode = parts[1];
                    string airline = parts[2];
                    string day = parts[3];
                    string time = parts[4];
                    int cost = int.Parse(parts[5]);
                    string name = parts[6];
                    string citizenship = parts[7];
                    string status = parts[8];

                    //For reservations should I just get the flight
                    reservationlist = new Reservation(reservationCode, flightCode, airline, day, time, cost, name, citizenship, status);
                    Reservations.Add(reservationlist);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public List<Reservation> MakeReservation(string code, Flight flight, string name, string citizenship)
        {
            Reservation reservation = new Reservation(reservationCode, name, citizenship, flight);

            Reservations.Add(reservation);

            return Reservations;
/*
            try
            {

                // Create and return a new reservation if criteria are met, otherwise throw an exception.
                string filePath = "..//Files/reservations.dat";
                using (BinaryWriter binWriter = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    foreach (var reservation in reservations)
                    {
                        binWriter.Write(UTF8Encoding.Default.GetBytes(
                           $"{reservation.ReservationCode}," +
                           $"{reservation.Name}," +
                           $"{reservation.Citizenship}," +
                           $"{reservation.Flight.FlightCode}," +
                           $"{reservation.Flight.FlightName}," +
                           $"{reservation.Flight.OriginatingAirport}," +
                           $"{reservation.Flight.DestinationAirport}," +
                           $"{reservation.Flight.DayOfWeek}," +
                           $"{reservation.Flight.FlightTime}," +
                           $"{reservation.Flight.SeatsAvailable}," +
                           $"{reservation.Flight.FlightPrice}," +
                           $"{reservation.Status}\n"
                       ));
                    }
                }

                {
                    //If a reservation is to be made but no flight is selected. Error message displayed.
                    if (string.IsNullOrEmpty(selectedFlightCode))
                    {
                        errorMessage = "Please select a flight before trying to make a reservation.";
                    }

                    //If name field is empty. Error message displayed.
                    if (string.IsNullOrEmpty(travelerName))
                    {
                        errorMessage = "Travelers Name is blank. Please enter traveler's name.";
                    }

                    //If citizenship field is empty. Error message is displayed.
                    if (string.IsNullOrEmpty(travelerCitizen))
                    {
                        errorMessage = "Travelers Citizenship is blank. Please enter traveler's citizenship.";
                    }

                    Flight selectedFlight = null;
                    //Loops throught flights list to find flight.
                    foreach (var flight in flights)
                    {
                        if (flight.Flight_Code == selectedFlightCode)
                        {
                            selectedFlight = flight;
                            break;
                        }
                    }

                    //If flight is completely booked. Throw an exception.
                    if (selectedFlight.Num_Seats <= 0)
                    {
                        throw new Exception("Selected flight is fully booked.");
                    }

                    //If flight is null. Throw an exception.
                    if (selectedFlight == null)
                    {
                        throw new Exception("Selected flight not found.");
                    }

                    //Reservation object is made.
                    //Reservation reservation = new Reservation(code, travelerName, travelerCitizen);
                    reservationCode = reservation.ReservationCode;

                    //Save reservation to file
                    string reservationCSV = reservation.toCSV();
                    PersistReservations(reservationCSV);

                    errorMessage = "Reservation successful! Reservation Code:";
                    return reservations;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
*/
        }

        public List<Reservation> FindReservations(string code, string airline, string name, List<Reservation>? reservationlist)
        {
            var selectedreservation = new List<Reservation>();
            //Loops throught reservations list to find reserved flight.
            foreach (var reservation in reservationlist)
            {
                if (reservation.ReservationCode.Equals(code) ||
                    reservation.Airline.Equals(airline) ||
                    reservation.TravelerName.Equals(name))
                {
                    selectedreservation.Add(reservation);
                }
            }

            return selectedreservation;
        }

        public void UpdateReservation()
        {

            string filePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\..\Files\reservation.csv"));
            using (BinaryWriter binWriter = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                foreach (var reservation in Reservations)
                {
                    binWriter.Write(UTF8Encoding.Default.GetBytes(
                       $"{reservation.ReservationCode}," +
                       $"{reservation.TravelerName}," +
                       $"{reservation.TravelerCitizen}," +
                       $"{reservation.Flight.Flight_Code}," +
                       $"{reservation.Flight.Airline}," +
                       $"{reservation.Flight.Origin_Airport}," +
                       $"{reservation.Flight.Destination_Airport}," +
                       $"{reservation.Flight.Day}," +
                       $"{reservation.Flight.Time}," +
                       $"{reservation.Flight.Num_Seats}," +
                       $"{reservation.Flight.Cost}," +
                       $"{reservation.Status}\n"
                   ));
                }
            }
        }

        public void PersistReservations(string reservations)
        {
            // Save reservations to a binary file.
            try
            {
                //string RESERVATION_TXT = Path.Combine(AppContext.BaseDirectory, "reservation.csv");
                string RESERVATION_TXT = Path.Combine(AppContext.BaseDirectory,  "Files", "reservation.csv");
                //Read all existing lines from the file.
                List<string> lines = new List<string>();
                if (File.Exists(RESERVATION_TXT))
                {
                    lines = File.ReadAllLines(RESERVATION_TXT).ToList();
                }

                //TODO: Append the reservationCsv string to the list of lines.
                lines.Add(reservations);
                //Write all lines back into file.
                File.WriteAllLines(RESERVATION_TXT, lines);
                
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                Console.WriteLine("Reservation has been updated!");
            }
        }
    }

}
