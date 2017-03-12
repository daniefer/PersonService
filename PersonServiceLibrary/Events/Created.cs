using System;
using MessagingLibrary;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace PersonServiceLibrary.Events
{
    public class Created : Event
    {
        [IgnoreDataMember]
        public override int Version { get => 1; }
        [IgnoreDataMember]
        public override Guid EventType => new Guid("F219CC97-C7E0-4C4A-B3EF-C4A95544123E");
        [IgnoreDataMember]
        public override string StreamName => this.EntityId.ToString("D");
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Prefix { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
    }
}
