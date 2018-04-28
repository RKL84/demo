CREATE TABLE [dbo].[Booking] (
    [Id]         BIGINT IDENTITY (1, 1) NOT NULL,
    [ScheduleId] BIGINT NOT NULL,
    [UserId]     BIGINT NOT NULL,
    [Status]     INT    NOT NULL,
    CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Booking_FlightSchedule] FOREIGN KEY ([ScheduleId]) REFERENCES [dbo].[FlightSchedule] ([Id]),
    CONSTRAINT [FK_Booking_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

