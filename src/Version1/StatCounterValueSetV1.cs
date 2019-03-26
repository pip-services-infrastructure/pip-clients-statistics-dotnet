using System;
using System.Runtime.Serialization;

namespace PipServices.Statistics.Client.Version1
{
    [DataContract]
    public class StatCounterValueSetV1
    {
        public StatCounterValueSetV1() { }

        [DataMember(Name = "group")]
        public string Group { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "type")]
        public StatCounterTypeV1 Type { get; set; }

        [DataMember(Name = "values")]
        public StatCounterValueV1[] Values { get; set; }
    }
}
