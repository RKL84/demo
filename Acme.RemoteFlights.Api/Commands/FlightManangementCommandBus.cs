using Acme.RemoteFlights.Core;
using Acme.RemoteFlights.Core.Commands;
using Autofac;

namespace Acme.RemoteFlights.Api.Commands
{
    public class FlightManangementCommandBus : CommandBus<AcmeObjectContext>
    {
        public FlightManangementCommandBus(ILifetimeScope scope) : base(scope)
        {
        }
    }
}
