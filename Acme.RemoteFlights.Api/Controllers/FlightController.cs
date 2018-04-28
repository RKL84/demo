using System.Threading.Tasks;
using Acme.RemoteFlights.Api.Requests;
using Acme.RemoteFlights.Core;
using Acme.RemoteFlights.Core.Commands;
using Acme.RemoteFlights.Core.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Acme.RemoteFlights.Api.ApiModels;

namespace Acme.RemoteFlights.Api.Controllers
{
    [Route("api/[controller]")]
    public class FlightController : BaseApiController
    {
        private readonly IFlightQueries _flightQueries;

        public FlightController(ICommandBus bus, IFlightQueries flightQueries) : base(bus)
        {
            _flightQueries = flightQueries;
        }

        // GET api/flight
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FlightSearchRequest request)
        {
            if (request == null)
                return BadRequest();
            var resultCollection = await _flightQueries.GetAllFlights(request.FlightNo, request.ArrivalCity,
                request.DepartureCity, request.ArrivalTime, request.DepartureTime, request.PassengerCapacity);
            var apiModelResultCollection = resultCollection.ToList().Select(i => FlightApiModel.FromFlightSchedule<FlightApiModel>(i));
            return Ok(apiModelResultCollection);
        }
    }
}
