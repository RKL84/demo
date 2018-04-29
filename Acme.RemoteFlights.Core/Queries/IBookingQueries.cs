using Acme.RemoteFlights.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.RemoteFlights.Core.Queries
{
    public interface IBookingQueries
    {
        Task<IEnumerable<Booking>> GetAllBookings(string passengerName, string departureCity, string arrivalCity, DateTime? travelDate, string flightNo);
        Task<IEnumerable<AvailableFlightInfo>> GetAvailableFlights(DateTime? startDate, DateTime? endDate, int numberOfPassengers);
        Task<IEnumerable<AvailableFlightInfo>> GetAvailableFlights(Int64 scheduleId, int numberOfPassengers);
    }
}
