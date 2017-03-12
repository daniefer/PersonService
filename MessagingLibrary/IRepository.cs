using System;
using System.Collections.Generic;
using System.Text;

namespace MessagingLibrary
{
    public interface IRepository
    {
        long ReadLastSequenceNumber(Event @event);

        (Guid EventId, long SequenceNumber) Insert(Event @event);

        IEnumerable<Event> GetLatestedEvents(Entity entity);
    }
}
