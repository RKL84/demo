CREATE PROCEDURE [sp_GetAvailableFlights] @StartDate datetime,
@EndDate datetime,
@NumberOfPassengers int

AS

BEGIN

  SELECT
    A.ArrivalCity,
    A.DepartureCity,
    A.ArrivalTime,
    A.DepartureTime,
    A.FlightCode
  FROM (SELECT
    FS.Id AS 'ScheduleId',
    FS.ArrivalCity,
    FS.DepartureCity,
    FS.ArrivalTime,
    FS.DepartureTime,
    F.FlightCode,
    F.PassengerCapacity
  FROM FlightSchedule FS
  INNER JOIN Flight F
    ON FS.FlightId = F.Id) AS A

  INNER JOIN (SELECT
    ScheduleId,
    COUNT(*) AS 'BookingCount'
  FROM Booking
  GROUP BY ScheduleId) AS B
    ON A.ScheduleId = B.ScheduleId
  WHERE DepartureTime >= @StartDate
  AND ArrivalTime <= @EndDate
  AND A.PassengerCapacity - B.BookingCount - @NumberOfPassengers > 0

END