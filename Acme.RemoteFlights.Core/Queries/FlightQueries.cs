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

        public async Task<IEnumerable<FlightSchedule>> GetAllFlights(string flightNo)
        {
            var query = (from scheduleInfo in _ctx.FlightSchedule
                         select scheduleInfo);

            if (!string.IsNullOrEmpty(flightNo))
            {
                query = query.Where(a => a.Flight.FlightCode.ToLower() == flightNo.ToLower());
            }

            return await query.Include(a => a.Flight).ToListAsync();
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

            if (arrivalTime.HasValue)
            {
                query = query.Where(a => arrivalTime.Value.Year == a.ArrivalTime.Year
                            && arrivalTime.Value.Month == a.ArrivalTime.Month
                            && arrivalTime.Value.Day == a.ArrivalTime.Day);
            }

            if (departureTime.HasValue)
            {
                query = query.Where(a => departureTime.Value.Year == a.DepartureTime.Year
                            && departureTime.Value.Month == a.DepartureTime.Month
                            && departureTime.Value.Day == a.DepartureTime.Day);
            }

            if (passengerCapacity.HasValue)
            {
                query = query.Where(a => a.Flight.PassengerCapacity >= passengerCapacity.Value);
            }

            return await query.Include(a => a.Flight).ToListAsync();
        }
    }
}
