using Acme.RemoteFlights.Core.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;

namespace Acme.RemoteFlights.Core.Queries
{
    public class BookingQueries : IBookingQueries
    {
        private readonly AcmeObjectContext _ctx;

        public BookingQueries(AcmeObjectContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Booking>> GetAllBookings(string passengerName, string departureCity,
            string arrivalCity, DateTime? travelDate, string flightNo)
        {
            var query = (from bookingInfo in _ctx.Booking
                         select bookingInfo);

            if (!string.IsNullOrEmpty(flightNo))
            {
                query = query.Where(a => a.FlightSchedule.Flight.FlightCode.ToLower() == flightNo.ToLower());
            }

            if (!string.IsNullOrEmpty(arrivalCity))
            {
                query = query.Where(a => a.FlightSchedule.ArrivalCity.ToLower() == arrivalCity.ToLower());
            }

            if (!string.IsNullOrEmpty(departureCity))
            {
                query = query.Where(a => a.FlightSchedule.DepartureCity.ToLower() == departureCity.ToLower());
            }

            if (!string.IsNullOrEmpty(passengerName))
            {
                query = query.Where(a => a.User.Name.ToLower() == passengerName.ToLower());
            }

            if (travelDate.HasValue)
            {
                query = query.Where(a => travelDate.Value.Year == a.FlightSchedule.DepartureTime.Year
                            && travelDate.Value.Month == a.FlightSchedule.DepartureTime.Month
                            && travelDate.Value.Day == a.FlightSchedule.DepartureTime.Day);
            }

            return await query.Include(a => a.FlightSchedule).Include(a => a.FlightSchedule.Flight).Include(a => a.User).ToListAsync();
        }

        public async Task<IEnumerable<AvailableFlightInfo>> GetAvailableFlights(DateTime startDate, DateTime endDate, int numberOfPassengers)
        {
            var startDateParameter = new SqlParameter("@StartDate", DateTime.Now);
            var endDateParameter = new SqlParameter("@EndDate", DateTime.Now);
            var numberOfPassengersParameter = new SqlParameter("@NumberOfPassengers", numberOfPassengers);
            var result = new List<AvailableFlightInfo>();
            using (var command = _ctx.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"sp_GetAvailableFlights";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(startDateParameter);
                command.Parameters.Add(endDateParameter);
                command.Parameters.Add(numberOfPassengersParameter);
                _ctx.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var data = new AvailableFlightInfo();
                        data.ScheduleId = (Int64)reader["ScheduleId"];
                        data.ArrivalCity = (string)reader["ArrivalCity"];
                        data.DepartureCity = (string)reader["DepartureCity"];
                        data.ArrivalTime = (DateTime)reader["ArrivalTime"];
                        data.DepartureTime = (DateTime)reader["DepartureTime"];
                        data.FlightCode = (string)reader["FlightCode"];
                        result.Add(data);
                    }
                }
            }

            return result;
        }
    }
}
