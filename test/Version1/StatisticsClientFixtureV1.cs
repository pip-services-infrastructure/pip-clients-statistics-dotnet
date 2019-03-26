using PipServices.Statistics.Client.Version1;
using PipServices3.Commons.Data;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PipServices.Statistics.Client.Test.Version1
{
    public class StatisticsClientFixtureV1
    {
        private IStatisticsClientV1 _client;

        public StatisticsClientFixtureV1(IStatisticsClientV1 client)
        {
            this._client = client;
        }

        public async Task TestCrudOperationsAsync()
        {
            // Increment counter
            await this._client.IncrementCounterAsync(null, "test", "value1", new DateTime(), "UTC", 1);
            Assert.True(!this._client.IncrementCounterAsync(null, "test", "value1", new DateTime(), "UTC", 1).IsFaulted);

            // Increment the same counter again
            await this._client.IncrementCountersAsync(null, 
                new StatCounterIncrementV1[] {
                    new StatCounterIncrementV1() {
                        Group = "test",
                        Name = "value1",
                        Value = 2
                    }
                });

            // Check all counters
            var page = await this._client.GetCountersAsync(null, null, new PagingParams());
            Assert.NotNull(page);
            Assert.Single(page.Data);

            //// Check total counters
            //var set = await this._client.ReadOneCounterAsync(null, "test", "value1", StatCounterTypeV1.Total, new DateTime(), new DateTime(), null);
            //var Set = await this._client.ReadOneCounterAsync(null, "test", "value2", StatCounterTypeV1.Total, new DateTime(), new DateTime(), null);
            //Assert.NotNull(set);
            //Assert.Single(set.Values);

            //var record = set.Values[0];
            //Assert.Equal(3, record.Value);

            //// Check counters by group
            //var sets = await this._client.ReadCountersByGroupAsync(null, "test", StatCounterTypeV1.Total, new DateTime(), new DateTime(), null);
            //Assert.Equal(1, sets.Length);

            //var _set = sets[0];
            //Assert.Single(_set.Values);

            //var _record = _set.Values[0];
            //Assert.Equal(3, _record.Value);

            //// Check monthly counters
            //var _sets = await this._client.ReadCountersAsync(null, 
            //    new StatCounterV1[] { new StatCounterV1("test", "value1") }, StatCounterTypeV1.Hour, new DateTime(), new DateTime(), "UTC");
            //Assert.Equal(1, _sets.Length);

            //var new_set = _sets[0];
            //Assert.Single(new_set.Values);

            //var new_record = new_set.Values[0];
            //Assert.Equal(3, new_record.Value);
        }
    }
}
