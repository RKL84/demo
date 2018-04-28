using System;

namespace Acme.RemoteFlights.Api.Requests
{
    public class BookingSearchRequest
    {
        public string FlightNo { get; set; }
        public string PassengerName { get; set; }
        public DateTime? TravelDate { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
    }
}
