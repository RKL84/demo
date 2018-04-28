using Acme.RemoteFlights.Core.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Acme.RemoteFlights.Core.Queries
{
    public class FlightQueries : IFlightQueries
    {
        private readonly AcmeObjectContext _ctx;

        public FlightQueries(AcmeObjectContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<FlightSchedule>> GetAllFlights(string flightNo, string arrivalCity,
            string departureCity, DateTime? arrivalTime, DateTime? departureTime, int? passengerCapacity)
        {
            var query = (from scheduleInfo in _ctx.FlightSchedule
                         select scheduleInfo);

            if (!string.IsNullOrEmpty(flightNo))
            {
                query = query.Where(a => a.Flight.FlightCode.ToLower() == flightNo.ToLower());
            }

            if (!string.IsNullOrEmpty(arrivalCity))
            {
                query = query.Where(a => a.ArrivalCity.ToLower() == arrivalCity.ToLower());
            }

            if (!string.IsNullOrEmpty(departureCity))
            {
                query = query.Where(a => a.DepartureCity.ToLower() == departureCity.ToLower());
            }

            if (passengerCapacity.HasValue)
            {
                query = query.Where(a => a.Flight.PassengerCapacity >= passengerCapacity.Value);
            }

            return await query.Include(a => a.Flight).ToListAsync();
        }
    }
}
