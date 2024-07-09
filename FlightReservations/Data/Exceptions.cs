using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data {
    /// <summary>
    /// Represents errors that occur during reservation processing.
    /// </summary>
    /// <remarks>
    /// Use this exception when a specific error occurs in the reservation workflow
    /// that cannot be handled by more generic exception types.
    /// </remarks>
    public class InvalidCitizenshipException: Exception {
        public InvalidCitizenshipException(): base("Invalid: The citizenship is not valid") {

        }

        public InvalidCitizenshipException(string citizenship): base("Invalid Citizinship: " + citizenship) {

        }
    }

    public class InvalidFlightCodeException: Exception {
        public InvalidFlightCodeException(): base("Invalid: The flight code is not valid") {

        }

        public InvalidFlightCodeException(string flightCode): base("Invalid Flight Code:" + flightCode) {

        }
    }

    public class InvalidNameException: Exception {
        public InvalidNameException(): base("Invalid: The name is not valid") {

        }

        public InvalidNameException(string name): base("Invalid Name:" + name) {

        }
    }

    public class NoMoreSeatsException: Exception {
        public NoMoreSeatsException(): base("Invalid: No more seat available") {

        }

        public NoMoreSeatsException(string numberOfSeats): base("Invalid Number of seats available:" + numberOfSeats) {

        }
    }

    public class ReservationValidationException: Exception {
        public ReservationValidationException(string message): base(message) {}

        public static void ValidateReservation(Reservation reservation) {
            if (reservation == null) {
                throw new ReservationValidationException("Reservation cannot be null.");
            }

            if (string.IsNullOrEmpty(reservation.ReservationCode) ||
                string.IsNullOrEmpty(reservation.Airline) ||
                reservation.Cost <= 0 ||
                string.IsNullOrEmpty(reservation.TravelerName) ||
                string.IsNullOrEmpty(reservation.TravelerCitizen) ||
                string.IsNullOrEmpty(reservation.Day) ||
                string.IsNullOrEmpty(reservation.Time) ||
                string.IsNullOrEmpty(reservation.FlightCode) ||
                string.IsNullOrEmpty(reservation.Status)) {
                throw new ReservationValidationException("All fields are required.");
            }
        }
    }
}