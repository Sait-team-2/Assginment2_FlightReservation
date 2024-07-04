using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data
{
    //Flight class: Class for creating Flight objects.
    public class Flight
    {
        private string flight_code;
        private string airline;
        private string origin_airport;
        private string destination_airport;
        private string day;
        private string time;
        private int num_seats;
        private double cost;

        public string Flight_Code { get { return flight_code; } set { flight_code = value; } }
        public string Airline { get {  return airline; } set {  airline = value; } }
        public string Origin_Airport { get { return origin_airport; } set { origin_airport = value; } }
        public string Destination_Airport { get { return destination_airport; } set { destination_airport = value; } }
        public string Day { get { return day; } set { day = value; } }
        public string Time { get { return time; } set { time = value; } }
        public int Num_Seats { get { return num_seats; } set { num_seats = value; } }
        public double Cost { get { return cost; } set { cost = value; } }
        //Default Constructor
        public Flight()
        {
        }
        //Parameterized Constructor
        public Flight(string flight_code, string airline, string origin_airport, string destination_airport, string day, string time, int num_seats, double cost)
        {
            this.Flight_Code = flight_code;
            this.Airline = airline;
            this.Origin_Airport = origin_airport;
            this.Destination_Airport = destination_airport;
            this.Day = day;
            this.Time = time;
            this.Num_Seats = num_seats;
            this.Cost = cost;
        }
    }
}
