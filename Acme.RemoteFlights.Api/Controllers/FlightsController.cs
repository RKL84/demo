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
    public class FlightsController : BaseApiController
    {
        private readonly IFlightQueries _flightQueries;

        public FlightsController(ICommandBus bus, IFlightQueries flightQueries) : base(bus)
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

        // GET api/flight
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var resultCollection = await _flightQueries.GetAllFlights(id);
            var apiModelResultCollection = resultCollection.ToList().Select(i => FlightApiModel.FromFlightSchedule<FlightApiModel>(i));
            return Ok(apiModelResultCollection);
        }
    }
}
