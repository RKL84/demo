using Acme.RemoteFlights.Api.Requests;
using Acme.RemoteFlights.Core;
using Acme.RemoteFlights.Core.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Acme.RemoteFlights.Api.Controllers
{
    [Route("api/[controller]")]
    public class TicketController : BaseApiController
    {
        public TicketController(ICommandBus bus) : base(bus)
        {
        }

        [HttpGet]
        public IEnumerable<string> Get([FromQuery] BookingSearchRequest request)
        {
            return new string[] { "value1", "value2" };
        }
    }
}
