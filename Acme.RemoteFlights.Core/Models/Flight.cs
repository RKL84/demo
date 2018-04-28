using System;
using System.Collections.Generic;

namespace Acme.RemoteFlights.Core.Models
{
    public class Flight
    {
        public Int64 Id { get; set; }
        public string FlightCode { get; set; }
        public int PassengerCapacity { get; set; }
        public List<FlightSchedule> FlightScheduleCollection { get; set; }
    }
}
