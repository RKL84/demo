using Acme.RemoteFlights.Api.Requests;
using Acme.RemoteFlights.Core.Commands;
using System.Collections.Generic;

namespace Acme.RemoteFlights.Api.Commands
{
    public class CreateBookingCommand : CommandBase
    {
        private readonly CreateBookingRequest _request;

        public CreateBookingRequest Request => _request;

        public CreateBookingCommand(CreateBookingRequest request)
        {
            _request = request;
        }

        protected override IEnumerable<string> OnValidation()
        {
            if (_request.ScheduleId == 0)
            {
                yield return "Must enter scheduleId";
            }

            if (_request.Age == 0)
            {
                yield return "Must enter age";
            }

            if (string.IsNullOrEmpty(_request.UserName))
            {
                yield return "Must enter an userName";
            }

            if (string.IsNullOrEmpty(_request.Email))
            {
                yield return "Must enter an email";
            }
        }
    }
}
