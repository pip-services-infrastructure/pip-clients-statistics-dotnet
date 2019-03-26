using System;
using System.Runtime.Serialization;

namespace PipServices.Statistics.Client.Version1
{
    [DataContract]
    public class StatCounterIncrementV1
    {
        public StatCounterIncrementV1() { }

        [DataMember(Name = "group")]
        public string Group { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "time")]
        public DateTime Time { get; set; }

        [DataMember(Name = "timezone")]
        public string Timezone { get; set; }

        [DataMember(Name = "value")]
        public int Value { get; set; }

    }
}
