using System.Linq;
using System.Threading.Tasks;
using Acme.RemoteFlights.Api.ApiModels;
using Acme.RemoteFlights.Api.Requests;
using Acme.RemoteFlights.Core;
using Acme.RemoteFlights.Core.Commands;
using Acme.RemoteFlights.Core.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Acme.RemoteFlights.Api.Controllers
{
    [Route("api/[controller]")]
    public class BookingController : BaseApiController
    {
        private IBookingQueries _bookingQueries;

        public BookingController(ICommandBus bus, IBookingQueries bookingQueries) : base(bus)
        {
            _bookingQueries = bookingQueries;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BookingSearchRequest request)
        {
            if (request == null)
                return BadRequest();
            var resultCollection = await _bookingQueries.GetAllBookings(request.PassengerName, request.DepartureCity,
                request.ArrivalCity, request.TravelDate, request.FlightNo);
            var apiModelResultCollection = resultCollection.ToList()
                .Select(i => BookingApiModel.FromFlightSchedule<BookingApiModel>(i));
            return Ok(apiModelResultCollection);
        }

        [HttpGet("availibility/")]
        public async Task<IActionResult> CheckAvailibility([FromQuery] TicketAvailbilitySearchRequest request)
        {
            if (request == null)
                return BadRequest();
            var resultCollection = await _bookingQueries.GetAvailableFlights(request.StartDate, request.EndDate,
                request.NumberOfPassengers);
            var apiModelResultCollection = resultCollection.ToList()
                .Select(i => AvailableFlightInfoApiModel.FromFlightSchedule<AvailableFlightInfoApiModel>(i));
            return Ok(resultCollection);
        }
    }
}
