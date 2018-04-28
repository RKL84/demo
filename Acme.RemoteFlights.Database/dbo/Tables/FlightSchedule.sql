CREATE TABLE [dbo].[FlightSchedule] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [FlightId]      BIGINT         NOT NULL,
    [DepartureCity] NVARCHAR (255) NOT NULL,
    [ArrivalCity]   NVARCHAR (255) NOT NULL,
    [DepartureTime] DATETIME       NOT NULL,
    [ArrivalTime]   DATETIME       NOT NULL,
    CONSTRAINT [PK_FlightSchedule] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FlightSchedule_Flight] FOREIGN KEY ([FlightId]) REFERENCES [dbo].[Flight] ([Id])
);

