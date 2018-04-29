using System;

namespace Acme.RemoteFlights.Api.Requests
{
    public class FlightAvailbilitySearchRequest 
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int NumberOfPassengers { get; set; }
    }
}
