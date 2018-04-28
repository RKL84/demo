CREATE TABLE [dbo].[User] (
    [Id]    BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (255) NOT NULL,
    [Age]   INT            NOT NULL,
    [Email] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

