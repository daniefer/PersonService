using System;
using MessagingLibrary;
using PersonServiceLibrary.Events;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace PersonServiceLibrary
{
    public class Repository : IRepository
    {
        private readonly string _connectionString;
        public Repository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public (Guid EventId, long SequenceNumber) Insert(Event @event)
        {
            Guid entityId;
            long sequenceNumber;

            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = @"INSERT INTO [EVENTS]
                        ([EntityId], [SequenceNumber], [Version], [EventType], [Data])
                        OUTPUT [inserted].[EntityId], [inserted].[SequenceNumber]
                        VALUES (@entityId, ISNULL((SELECT MAX([SequenceNumber]) FROM [Events] WHERE [EntityId] = @entityId), 0) + 1, @version, @eventType, @data)";
                    command.Parameters.AddWithValue("@entityId", @event.EntityId);
                    command.Parameters.AddWithValue("@version", @event.Version);
                    command.Parameters.AddWithValue("@eventType", @event.EventType);
                    command.Parameters.AddWithValue("@data", @event.ToJson());
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var oEntityId = reader.GetOrdinal("EntityId");
                        var oSequenceNumber = reader.GetOrdinal("SequenceNumber");
                        reader.Read();
                        entityId = reader.GetGuid(oEntityId);
                        sequenceNumber = reader.GetInt64(oSequenceNumber);
                    }
                }
            }

            return (entityId, sequenceNumber);
        }

        public long ReadLastSequenceNumber(Event @event)
        {
            long sequenceNumber;

            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT MAX([SequenceNumber]) AS [SequenceNumber] " +
                        "FROM [Events] WHERE [EntityId] = @entityId";
                    command.Parameters.AddWithValue("@entityId", @event.EntityId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var oSequenceNumber = reader.GetOrdinal("SequenceNumber");
                        reader.Read();
                        if (reader.IsDBNull(oSequenceNumber))
                        {
                            sequenceNumber = 0;
                        }
                        else
                        {
                            sequenceNumber = reader.GetInt64(oSequenceNumber);
                        }
                    }
                }
            }

            return sequenceNumber;
        }

        public IEnumerable<Event> GetLatestedEvents(Entity entity)
        {
            yield return new Created
            {
                EventId = entity.EntityId
            };
        }
    }
}
