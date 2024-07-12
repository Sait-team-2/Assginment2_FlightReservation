using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlightReservations.Data
{
    public class ReservationManager
    {
        public string Airline { get; set; } = string.Empty;
        public string TravelerName { get; set; } = string.Empty;
        public string TravelerCitizen { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public string ReservationCode { get; set; } = string.Empty;
        public string SelectedFlightCode { get; set; } = string.Empty;

        // Method to get all reservations
        public List<Reservation> GetReservations()
        {
            string filePath = @"..\FlightReservations\Files\reservation.csv";
            List<Reservation> reservations = new List<Reservation>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var fields = line.Split(',');
                    var reservation = new Reservation
                    {
                        FlightCode = fields[0],
                        TravelerName = fields[1],
                        TravelerCitizen = fields[2],
                        ReservationCode = fields[3]
                    };
                    reservations.Add(reservation);
                }
            }

            return reservations;
        }

        // Method to find reservations based on a search term
        public List<Reservation> FindReservations(string searchTerm)
        {
            var reservations = GetReservations();
            return reservations.Where(r =>
                r.TravelerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                r.TravelerCitizen.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                r.ReservationCode.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Method to update an existing reservation
        public void UpdateReservation(Reservation updatedReservation)
        {
            string filePath = @"..\FlightReservations\Files\reservation.csv";
            List<string> lines = new List<string>();

            if (File.Exists(filePath))
            {
                lines = File.ReadAllLines(filePath).ToList();
            }

            var updatedLines = lines.Select(line =>
            {
                var fields = line.Split(',');
                if (fields[3] == updatedReservation.ReservationCode)
                {
                    fields[0] = updatedReservation.FlightCode;
                    fields[1] = updatedReservation.TravelerName;
                    fields[2] = updatedReservation.TravelerCitizen;
                }
                return string.Join(",", fields);
            }).ToList();

            File.WriteAllLines(filePath, updatedLines);
        }

        public void MakeReservation()
        {
            // Your existing code to make a reservation
        }

        public void SaveReservationCsv(string reservationCsv)
        {
            try
            {
                string RESERVATION_TXT = @"..\FlightReservations\Files\reservation.csv";
                List<string> lines = new List<string>();
                if (File.Exists(RESERVATION_TXT))
                {
                    lines = File.ReadAllLines(RESERVATION_TXT).ToList();
                }

                lines.Add(reservationCsv);
                File.WriteAllLines(RESERVATION_TXT, lines);

                ErrorMessage = "Reservation saved successfully!";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
