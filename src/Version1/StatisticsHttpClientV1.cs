using System;
using System.Threading.Tasks;
using PipServices3.Commons.Config;
using PipServices3.Commons.Data;
using PipServices3.Rpc.Clients;

namespace PipServices.Statistics.Client.Version1
{
    public class StatisticsHttpClientV1 : CommandableHttpClient, IStatisticsClientV1
    {
        public StatisticsHttpClientV1() : base("v1/statistics") { }

        public StatisticsHttpClientV1(object config) : base("v1/statistics")
        {
            if (config != null)
                this.Configure(ConfigParams.FromValue(config));
        }

        public async Task<DataPage<string>> GetGroupsAsync(string correlationId, PagingParams paging)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<DataPage<string>>(
                    "get_groups",
                    correlationId,
                    new
                    {
                        paging = paging
                    }
                );
            }
        }

        public async Task<DataPage<StatCounterV1>> GetCountersAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<DataPage<StatCounterV1>>(
                    "get_counters",
                    correlationId,
                    new
                    {
                        filter = filter,
                        paging = paging
                    }
                );
            }
        }

        public Task IncrementCounterAsync(string correlationId, string group, string name, DateTime time, string timezone, int value)
        {
            using (var timing = Instrument(correlationId))
            {
                return CallCommandAsync<Task>(
                    "increment_counter",
                    correlationId,
                    new
                    {
                        group = group,
                        name = name,
                        time = time,
                        timezone = timezone,
                        value = value
                    }
                );
            }
        }

        public Task IncrementCountersAsync(string correlationId, StatCounterIncrementV1[] increments)
        {
            using (var timing = Instrument(correlationId))
            {
                return CallCommandAsync<Task>(
                    "increment_counters",
                    correlationId,
                    new
                    {
                        increments = increments
                    }
                );
            }
        }

        public async Task<StatCounterValueSetV1> ReadOneCounterAsync(string correlationId, string group, string name, int type, DateTime fromTime, DateTime toTime, string timezone)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<StatCounterValueSetV1>(
                    "read_one_counter",
                    correlationId,
                    new
                    {
                        group = group,
                        name = name,
                        type = type,
                        from_time = fromTime,
                        to_time = toTime,
                        timezone = timezone
                    }
                );
            }
        }

        public async Task<StatCounterValueSetV1[]> ReadCountersByGroupAsync(string correlationId, string group, int type, DateTime fromTime, DateTime toTime, string timezone)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<StatCounterValueSetV1[]>(
                    "read_counters_by_group",
                    correlationId,
                    new
                    {
                        group = group,
                        type = type,
                        from_time = fromTime,
                        to_time = toTime,
                        timezone = timezone
                    }
                );
            }
        }

        public async Task<StatCounterValueSetV1[]> ReadCountersAsync(string correlationId, StatCounterV1[] counters, int type, DateTime fromTime, DateTime toTime, string timezone)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<StatCounterValueSetV1[]>(
                    "read_counters",
                    correlationId,
                    new
                    {
                        counters = counters,
                        type = type,
                        from_time = fromTime,
                        to_time = toTime,
                        timezone = timezone
                    }
                );
            }
        }
    }
}
