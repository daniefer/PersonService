using System;
using MessagingLibrary;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace PersonServiceLibrary.Events
{
    public class NameChanged : Event
    {
        [IgnoreDataMember]
        public override int Version { get => 1; }
        [IgnoreDataMember]
        public override Guid EventType { get => new Guid("D4179334-C97F-4C24-B58E-996F93EF7B5B"); }
        [IgnoreDataMember]
        public override string StreamName => this.EntityId.ToString("D");
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Prefix { get; set; }
    }
}
