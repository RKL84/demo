using Acme.RemoteFlights.Core;
using Acme.RemoteFlights.Core.Commands;
using Acme.RemoteFlights.Core.Models;
using Acme.RemoteFlights.Core.Queries;
using System.Linq;

namespace Acme.RemoteFlights.Api.Commands
{
    public class CreateBookingCommandHandler : ICommandHandler<CreateBookingCommand>
    {
        private readonly AcmeObjectContext _ctx;
        private readonly IBookingQueries _bookingQueries;

        public CreateBookingCommandHandler(AcmeObjectContext ctx, IBookingQueries bookingQueries)
        {
            _ctx = ctx;
            _bookingQueries = bookingQueries;
        }

        public CommandHandlerResult Handle(CreateBookingCommand command)
        {
            var result = _bookingQueries.GetAvailableFlights(command.Request.ScheduleId, 1).Result;
            if (!result.Any())
                return CommandHandlerResult.Error("No tickets available for the schedule");

            var user = _ctx.User.SingleOrDefault(u => u.Email == command.Request.Email);
            if (user == null)
            {
                user = (new User
                {
                    Age = command.Request.Age,
                    Email = command.Request.Email,
                    Name = command.Request.UserName
                });
                _ctx.User.Add(user);
            }

            _ctx.Booking.Add(new Booking()
            {
                ScheduleId = command.Request.ScheduleId,
                User = user,
                Status = (int)BookingStatus.Confirmed
            });
            return CommandHandlerResult.Ok;
        }
    }
}
