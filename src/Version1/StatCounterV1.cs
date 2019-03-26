using System.Runtime.Serialization;

namespace PipServices.Statistics.Client.Version1
{
    [DataContract]
    public class StatCounterV1
    {
        public StatCounterV1() { }

        public StatCounterV1(string group, string name)
        {
            Group = group;
            Name = name;
        }

        [DataMember(Name = "group")]
        public string Group { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
