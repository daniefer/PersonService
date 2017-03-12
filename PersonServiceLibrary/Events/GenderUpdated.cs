using System;
using MessagingLibrary;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace PersonServiceLibrary.Events
{
    public class GenderUpdated : Event
    {
        [IgnoreDataMember]
        public override int Version { get => 1; }
        [IgnoreDataMember]
        public override Guid EventType { get => new Guid("57057881-AE98-4A62-819E-EA53A3B42D62"); }
        [IgnoreDataMember]
        public override string StreamName => this.EntityId.ToString("D");
        public string Gender { get; set; }
    }
}
