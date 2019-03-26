using PipServices.Statistics.Client.Version1;
using PipServices3.Commons.Refer;
using PipServices3.Components.Build;

namespace PipServices.Statistics.Client.Build
{
    public class StatisticsClientFactory : Factory 
    {
        public static Descriptor Descriptor = new Descriptor("pip-services-statistics", "factoty", "*", "*", "1.0");
        public static Descriptor NullClientV1Descriptor = new Descriptor("pip-services-statistics", "client", "null", "*", "1.0");
        public static Descriptor HttpClientV1Descriptor = new Descriptor("pip-services-statistics", "client", "http", "*", "1.0");

        public StatisticsClientFactory()
        {
            RegisterAsType(NullClientV1Descriptor, typeof(StatisticsNullClientV1));
            RegisterAsType(HttpClientV1Descriptor, typeof(StatisticsHttpClientV1));
        }

    }
}
