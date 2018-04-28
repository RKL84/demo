using Acme.RemoteFlights.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.RemoteFlights.Core.Queries
{
    public interface IFlightQueries
    {
        Task<IEnumerable<FlightSchedule>> GetAllFlights(string flightNo, string arrivalCity, string departureCity,
            DateTime? arrivalTime, DateTime? departureTime, int? passengerCapacity);
    }
}
