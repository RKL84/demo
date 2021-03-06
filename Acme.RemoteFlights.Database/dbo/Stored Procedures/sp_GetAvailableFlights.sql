﻿CREATE PROCEDURE [dbo].[sp_GetAvailableFlights] 
@StartDate datetime = NULL ,
@EndDate datetime  = NULL,
@NumberOfPassengers int  = 0

AS

BEGIN

  SELECT DISTINCT
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
    ON FS.FlightId = F.Id) AS A

  LEFT OUTER JOIN (SELECT
    ScheduleId,
    COUNT(*) AS 'BookingCount'
  FROM Booking
  GROUP BY ScheduleId) AS B
    ON A.ScheduleId = B.ScheduleId
  WHERE
  CAST(DepartureTime AS DATE) = CAST(ISNULL(@StartDate,DepartureTime) AS DATE)
  AND CAST(ArrivalTime AS DATE) = CAST(ISNULL(@EndDate,ArrivalTime) AS DATE)
  AND A.PassengerCapacity - ISNULL(B.BookingCount,0) - @NumberOfPassengers >= 0

END