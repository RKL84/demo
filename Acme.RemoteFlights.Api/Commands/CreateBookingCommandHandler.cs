using Acme.RemoteFlights.Core;
using Acme.RemoteFlights.Core.Commands;
using Acme.RemoteFlights.Core.Models;
using System.Linq;

namespace Acme.RemoteFlights.Api.Commands
{
    public class CreateBookingCommandHandler : ICommandHandler<CreateBookingCommand>
    {
        private readonly AcmeObjectContext _ctx;
        public CreateBookingCommandHandler(AcmeObjectContext ctx)
        {
            _ctx = ctx;
        }

        public CommandHandlerResult Handle(CreateBookingCommand command)
        {
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
