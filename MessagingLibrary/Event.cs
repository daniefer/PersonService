using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MessagingLibrary
{
    public abstract class Event
    {
        [IgnoreDataMember]
        public Guid EventId { get; set; }
        [IgnoreDataMember]
        public long SequenceNumber { get; set; }
        [IgnoreDataMember]
        public virtual int Version { get; set; }
        [IgnoreDataMember]
        public virtual Guid EventType { get; set; }

        [IgnoreDataMember]
        public abstract string StreamName
        {
            get;
        }

        public Guid EntityId { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static T FromJson<T>(string json) where T: Event
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
