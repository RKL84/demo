using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acme.RemoteFlights.Core.Models
{
    public class Booking
    {
        [ForeignKey("ScheduleId")]
        public FlightSchedule FlightSchedule { get; set; }
        public User User { get; set; }
        public Int64 Id { get; set; }
        public Int64 ScheduleId { get; set; }
        public Int64 UserId { get; set; }
        public int Status { get; set; }
    }
}
