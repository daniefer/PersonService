using System;
using MessagingLibrary;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace PersonServiceLibrary.Events
{
    public class DOBChanged : Event
    {
        [IgnoreDataMember]
        public override int Version { get => 1; }
        [IgnoreDataMember]
        public override Guid EventType { get => new Guid("02BD43EB-E6F9-4E17-9868-C526E61C568A"); }
        [IgnoreDataMember]
        public override string StreamName => this.EntityId.ToString("D");
        public DateTime DOB { get; set; }
    }
}
