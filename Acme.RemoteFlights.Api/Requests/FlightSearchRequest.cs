using System;

namespace Acme.RemoteFlights.Api.Requests
{
    public class FlightSearchRequest
    {
        public string FlightNo { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int? PassengerCapacity { get; set; }
    }
}
