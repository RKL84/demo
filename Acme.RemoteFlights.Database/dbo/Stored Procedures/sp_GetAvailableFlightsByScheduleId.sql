CREATE PROCEDURE [dbo].[sp_GetAvailableFlightsByScheduleId]
@ScheduleId bigint,
@NumberOfPassengers int

AS

BEGIN

  SELECT
    A.ScheduleId,
    A.ArrivalCity,
    A.DepartureCity,
    A.ArrivalTime,
    A.DepartureTime,
    A.FlightCode,
	A.PassengerCapacity - ISNULL(B.BookingCount,0) AS 'AvailableSeats'
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
    ON FS.FlightId = F.Id 
	WHERE FS.Id = @ScheduleId) AS A

  LEFT OUTER  JOIN (SELECT
    ScheduleId,
    COUNT(*) AS 'BookingCount'
  FROM Booking
  GROUP BY ScheduleId) AS B
    ON A.ScheduleId = B.ScheduleId
  AND A.PassengerCapacity - ISNULL(B.BookingCount,0) - @NumberOfPassengers >= 0

END