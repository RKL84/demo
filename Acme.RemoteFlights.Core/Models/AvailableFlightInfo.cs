using System;

namespace Acme.RemoteFlights.Core.Models
{
    public class AvailableFlightInfo
    {
        public Int64 ScheduleId { get; set; }
        public string FlightCode { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
