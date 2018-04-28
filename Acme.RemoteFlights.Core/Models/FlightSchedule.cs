using System;

namespace Acme.RemoteFlights.Core.Models
{
    public class FlightSchedule
    {
        public Int64 Id { get; set; }
        public Int64 FlightId { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Flight Flight { get; set; }
    }
}
