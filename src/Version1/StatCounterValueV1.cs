using System.Runtime.Serialization;

namespace PipServices.Statistics.Client.Version1
{
    [DataContract]
    public class StatCounterValueV1
    {
        public StatCounterValueV1() { }

        [DataMember(Name = "year")]
        public int Year { get; set; }

        [DataMember(Name = "month")]
        public int Month { get; set; }

        [DataMember(Name = "day")]
        public int Day { get; set; }

        [DataMember(Name = "hour")]
        public int Hour { get; set; }

        [DataMember(Name = "value")]
        public int Value { get; set; }
    }
}