using PipServices.Statistics.Client.Version1;
using PipServices3.Commons.Config;
using PipServices3.Commons.Data;
using System;

namespace PipServices.Statistics.Client.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var correlationId = "123";
                var config = ConfigParams.FromTuples(
                    "connection.type", "http",
                    "connection.host", "localhost",
                    "connection.port", 8080
                );
                var client = new StatisticsHttpClientV1();

                client.Configure(config);
                client.OpenAsync(correlationId);

                client.IncrementCounterAsync(null, "test", "value1", new DateTime(), "UTC", 1);
                //var set = client.ReadOneCounterAsync(null, "test", "value1", StatCounterTypeV1.Total, new DateTime(), new DateTime(), null);
                Console.WriteLine("Counter added and read");
                var page = client.GetCountersAsync(null, null, new PagingParams());
                Console.WriteLine("Page: " + page.Result);

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();

                client.CloseAsync(string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
