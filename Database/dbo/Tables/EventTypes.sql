CREATE TABLE [dbo].[EventTypes] (
    [Id]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Type]    NVARCHAR (255)   NOT NULL,
    [Version] INT              NOT NULL,
    CONSTRAINT [PK_EventTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

