using System;

namespace Acme.RemoteFlights.Api.Requests
{
    public class CreateBookingRequest
    {
        public Int64 ScheduleId { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
