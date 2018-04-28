using Acme.RemoteFlights.Core.Models;
using System;

namespace Acme.RemoteFlights.Api.ApiModels
{
    public class AvailableFlightInfoApiModel
    {
        public Int64 ScheduleId { get; set; }
        public string FlightCode { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public static TModel FromFlightSchedule<TModel>(AvailableFlightInfo data) where
     TModel : AvailableFlightInfoApiModel, new()
        {
            var model = new TModel();
            model.ScheduleId = data.ScheduleId;
            model.FlightCode = data.FlightCode;
            model.DepartureCity = data.DepartureCity;
            model.ArrivalCity = data.ArrivalCity;
            model.DepartureTime = data.DepartureTime;
            model.ArrivalTime = data.ArrivalTime;
            return model;
        }
    }
}
