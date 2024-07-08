using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservations.Data
{
	public class InvalidCitizenshipException : Exception
	{
		public InvalidCitizenshipException() : base("Invalid: The citizenship is not valid")
		{

		}
        
		public InvalidCitizenshipException(string citizenship) : base("Invalid Citizinship: "+ citizenship)
        {

        }
    }

	    public class InvalidFlightCodeException : Exception
    {
        public InvalidFlightCodeException() : base("Invalid: The flight code is not valid")
        {

        }

        public InvalidFlightCodeException(string flightCode) : base("Invalid Flight Code:" + flightCode) 
        {
            
        }
    }

        public class InvalidNameException : Exception
    {
        public InvalidNameException() : base("Invalid: The name is not valid")
        {

        }

        public InvalidNameException(string name) : base("Invalid Name:" + name)
        {

        }
    }

        public class NoMoreSeatsException : Exception
    {
        public NoMoreSeatsException() : base("Invalid: No more seat available")
        {

        }

        public NoMoreSeatsException(string numberOfSeats) : base("Invalid Number of seats available:" + numberOfSeats)
        {

        }
    }
}
