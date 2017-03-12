using System;
using System.Collections.Generic;
using System.Text;

namespace MessagingLibrary
{
    public class Entity
    {
        public Guid EntityId { get; set; }
        public long SequenceNumber { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
