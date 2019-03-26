using PipServices.Statistics.Client.Version1;
using PipServices3.Commons.Config;
using System.Threading.Tasks;
using Xunit;

namespace PipServices.Statistics.Client.Test.Version1
{
    public class StatisticsHttpClientV1Test
    {
        private static readonly ConfigParams HttpConfig = ConfigParams.FromTuples(
        "connection.protocol", "http",
        "connection.host", "localhost",
        "connection.port", 8080);

        private readonly StatisticsHttpClientV1 _client;
        private readonly StatisticsClientFixtureV1 _fixture;

        public StatisticsHttpClientV1Test()
        {
            _client = new StatisticsHttpClientV1();
            _client.Configure(HttpConfig);

            _fixture = new StatisticsClientFixtureV1(_client);

            _client.OpenAsync(null);
        }

        [Fact]
        public async Task TestCrudOperations()
        {
            await _fixture.TestCrudOperationsAsync();
        }

        public void Dispose()
        {
            _client.CloseAsync(null);
        }
    }
}
