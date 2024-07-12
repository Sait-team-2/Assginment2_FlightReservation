using Blazorise;
using System;
using System.IO;

namespace FlightReservations.Data
{ 
    /// <summary>
    /// The <c>ReservationManager</c> class is a central component within a flight reservation
    /// system. It is designed to manage various aspects of flight reservations, including
    /// storing, retrieving, and updating reservation data. This class serves as the backbone
    /// for handling the reservation logic in the application.
    /// </summary>
    /// <remarks>
    /// This class includes methods for populating reservations from a file, finding specific
    /// reservations based on criteria, and updating reservations.
    /// </remarks>
    public class ReservationManager
    {
        public List<Flight> flights;
        public string Airline { get; set; } = string.Empty;
        public string TravelerName { get; set; } = string.Empty;
        public string TravelerCitizen { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public string ReservationCode { get; set; } = string.Empty;
        public string SelectedFlightCode { get; set; } = string.Empty;

        public static List<Reservation> Reservations = new List<Reservation>(); 
       
        static string filePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\..\Files\reservation.csv"));
        public ReservationManager()
        {
            flights = new List<Flight>();
            Reservations = new List<Reservation>();
            GetReservations();
        }

        //static method that can be accessed throughout the project
        public static List<Reservation> GetReservations()
        {
            try
            {
                Reservation reservationlist;
                List<Reservation> reservations = new List<Reservation>();
                

                //Foreach loop: Reads flights.csv file, splits data "," and loads data into individual variables. Finally creates flight objects and loads it into Flights list.
                foreach (string line in File.ReadLines(filePath))
                {
                    string[] parts = line.Split(",");
                    string reservationCode = parts[0];
                    string flightCode = parts[1];
                    string airline = parts[2];
                    string day = parts[3];
                    string time = parts[4];
                    double cost = double.Parse(parts[5]);
                    string name = parts[6];
                    string citizenship = parts[7];
                    string status = parts[8];

                    reservationlist = new Reservation(reservationCode, flightCode, airline, day, time, cost, name, citizenship, status);
                    Reservations.Add(reservationlist);
                }

                return Reservations;
            }
             catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Reservations;
            }

        }

        // Method to find reservations based on a search term
        public List<Reservation> FindReservations(string code, string airline, string name, List<Reservation>? reservationlist)
        {
            var selectedreservation = new List<Reservation>();
            // Loops through reservations list to find reserved flight.
            foreach (var reservation in reservationlist)
            {
                bool codeMatch = string.IsNullOrEmpty(code) || reservation.ReservationCode.Equals(code);
                bool airlineMatch = string.IsNullOrEmpty(airline) || reservation.Airline.Equals(airline);
                bool nameMatch = string.IsNullOrEmpty(name) || reservation.TravelerName.Equals(name);

                if (codeMatch && airlineMatch && nameMatch)
                {
                    selectedreservation.Add(reservation);
                }
            }

            return selectedreservation;
        }

        public class OperationResult
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }

            public OperationResult(bool isSuccess, string message)
            {
                IsSuccess = isSuccess;
                Message = message;
            }
        }


        public OperationResult UpdateReservation(Reservation newReservation)
        {
            try
            {
                string RESERVATION_PATH = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\..\Files\reservation.csv"));
                List<string> lines = new List<string>();

                if (File.Exists(RESERVATION_PATH))
                {
                    lines = File.ReadAllLines(RESERVATION_PATH).ToList();

                    bool reservationFound = false;
                    for (int i = 0; i < lines.Count; i++)
                    {
                        string[] parts = lines[i].Split(',');
                        if (parts[0] == newReservation.ReservationCode) 
                        {
                            lines[i] = $"{newReservation.ReservationCode},{newReservation.FlightCode},{newReservation.Airline},{newReservation.Day},{newReservation.Time},{newReservation.Cost},{newReservation.TravelerName},{newReservation.TravelerCitizen},{newReservation.Status}";
                            reservationFound = true;
                            break;
                        }
                    }

                    if (!reservationFound)
                    {
                        lines.Add($"{newReservation.ReservationCode},{newReservation.FlightCode},{newReservation.Airline},{newReservation.Day},{newReservation.Time},{newReservation.Cost},{newReservation.TravelerName},{newReservation.TravelerCitizen},{newReservation.Status}");
                    }
                }
                else
                {
                    lines.Add($"{newReservation.ReservationCode},{newReservation.FlightCode},{newReservation.Airline},{newReservation.Day},{newReservation.Time},{newReservation.Cost},{newReservation.TravelerName},{newReservation.TravelerCitizen},{newReservation.Status}");
                }

                // Write the updated list back to the file
                File.WriteAllLines(RESERVATION_PATH, lines);

                return new OperationResult(true, "File Updated successfully");
            }
            catch (UnauthorizedAccessException ex)
            {
                return new OperationResult(false, $"Unauthorized access: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }
        }

    }
}
