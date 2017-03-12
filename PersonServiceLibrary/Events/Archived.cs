using System;
using MessagingLibrary;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace PersonServiceLibrary.Events
{
    public class Archived : Event
    {
        [IgnoreDataMember]
        public override int Version { get => 1; }
        [IgnoreDataMember]
        public override Guid EventType => new Guid("9930EC93-0634-490F-8465-7C809A85D8A0");
        [IgnoreDataMember]
        public override string StreamName => this.EntityId.ToString("D");

    }
}
