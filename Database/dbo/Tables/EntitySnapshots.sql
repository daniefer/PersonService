CREATE TABLE [dbo].[EntitySnapshots] (
    [TimeStamp]      ROWVERSION       NOT NULL,
    [EntityId]       UNIQUEIDENTIFIER NOT NULL,
    [SequenceNumber] BIGINT           NOT NULL,
    [Snapshot]       NVARCHAR (MAX)   NOT NULL
);

