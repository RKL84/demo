using Acme.RemoteFlights.Core.Models;
using System;

namespace Acme.RemoteFlights.Api.ApiModels
{
    public class FlightApiModel
    {
        public string FlightCode { get; set; }
        public int PassengerCapacity { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }


        public static TModel FromFlightSchedule<TModel>(FlightSchedule data) where
           TModel : FlightApiModel, new()
        {
            var model = new TModel();
            model.FlightCode = data.Flight.FlightCode;
            model.PassengerCapacity = data.Flight.PassengerCapacity;
            model.ArrivalCity = data.ArrivalCity;
            model.DepartureCity = data.DepartureCity;
            model.ArrivalTime = data.ArrivalTime;
            model.DepartureTime = data.DepartureTime;
            return model;
        }
    }
}
