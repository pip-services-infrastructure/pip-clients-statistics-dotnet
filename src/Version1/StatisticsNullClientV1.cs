using System;
using System.Threading.Tasks;
using PipServices3.Commons.Data;

namespace PipServices.Statistics.Client.Version1
{
    public class StatisticsNullClientV1 : IStatisticsClientV1
    {

        public async Task<DataPage<string>> GetGroupsAsync(string correlationId, PagingParams paging)
        {
            return await Task.FromResult(new DataPage<string>());
        }

        public async Task<DataPage<StatCounterV1>> GetCountersAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            return await Task.FromResult(new DataPage<StatCounterV1>());
        }

        public Task IncrementCounterAsync(string correlationId, string group, string name, DateTime time, string timezone, int value)
        {
            return Task.Delay(0);
        }

        public Task IncrementCountersAsync(string correlationId, StatCounterIncrementV1[] increments)
        {
            return Task.Delay(0);
        }

        public async Task<StatCounterValueSetV1> ReadOneCounterAsync(string correlationId, string group, string name, int type, DateTime fromTime, DateTime toTime, string timezone)
        {
            return await Task.FromResult(new StatCounterValueSetV1());
        }

        public async Task<StatCounterValueSetV1[]> ReadCountersByGroupAsync(string correlationId, string group, int type, DateTime fromTime, DateTime toTime, string timezone)
        {
            return await Task.FromResult(new StatCounterValueSetV1[] { });
        }

        public async Task<StatCounterValueSetV1[]> ReadCountersAsync(string correlationId, StatCounterV1[] counters, int type, DateTime fromTime, DateTime toTime, string timezone)
        {
            return await Task.FromResult(new StatCounterValueSetV1[] { });
        }
    }
}
