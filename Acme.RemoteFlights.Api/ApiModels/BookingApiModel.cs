using Acme.RemoteFlights.Core.Models;
using System;

namespace Acme.RemoteFlights.Api.ApiModels
{
    public class BookingApiModel
    {
        public string FlightCode { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }


        public static TModel FromFlightSchedule<TModel>(Booking data) where
        TModel : BookingApiModel, new()
        {
            var model = new TModel();
            model.FlightCode = data.FlightSchedule.Flight.FlightCode;
            model.ArrivalCity = data.FlightSchedule.ArrivalCity;
            model.DepartureCity = data.FlightSchedule.DepartureCity;
            model.ArrivalTime = data.FlightSchedule.ArrivalTime;
            model.DepartureTime = data.FlightSchedule.DepartureTime;
            model.Name = data.User.Name;
            model.Age = data.User.Age;
            model.Email = data.User.Email;
            model.Status = data.Status.ToString();
            return model;
        }
    }
}
