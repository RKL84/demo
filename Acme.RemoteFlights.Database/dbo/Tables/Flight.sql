CREATE TABLE [dbo].[Flight] (
    [Id]                BIGINT        IDENTITY (1, 1) NOT NULL,
    [FlightCode]        NVARCHAR (50) NOT NULL,
    [PassengerCapacity] INT           NOT NULL,
    CONSTRAINT [PK_Flight] PRIMARY KEY CLUSTERED ([Id] ASC)
);

