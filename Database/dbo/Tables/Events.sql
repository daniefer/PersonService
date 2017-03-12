CREATE TABLE [dbo].[Events] (
    [EntityId]       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [SequenceNumber] BIGINT           NOT NULL,
    [Version]        INT              NOT NULL,
    [Timestamp]      ROWVERSION       NOT NULL,
    [EventType]      UNIQUEIDENTIFIER NOT NULL,
    [Data]           NVARCHAR (MAX)   NOT NULL,
    PRIMARY KEY CLUSTERED ([EntityId] ASC, [SequenceNumber] ASC),
    CONSTRAINT [FK_Events_EventTypes] FOREIGN KEY ([EventType]) REFERENCES [dbo].[EventTypes] ([Id])
);

