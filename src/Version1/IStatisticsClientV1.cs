using PipServices3.Commons.Data;
using System;
using System.Threading.Tasks;

namespace PipServices.Statistics.Client.Version1
{
    public interface IStatisticsClientV1
    {
        Task<DataPage<string>> GetGroupsAsync(string correlationId, PagingParams paging);
        Task<DataPage<StatCounterV1>> GetCountersAsync(string correlationId, FilterParams filter, PagingParams paging);
        Task IncrementCounterAsync(string correlationId, string group, string name, DateTime time, string timezone, int value);
        Task IncrementCountersAsync(string correlationId, StatCounterIncrementV1[] increments);
        Task<StatCounterValueSetV1> ReadOneCounterAsync(string correlationId, string group, string name, int type, DateTime fromTime, DateTime toTime, string timezone);
        Task<StatCounterValueSetV1[]> ReadCountersByGroupAsync(string correlationId, string group, int type, DateTime fromTime, DateTime toTime, string timezone);
        Task<StatCounterValueSetV1[]> ReadCountersAsync(string correlationId, StatCounterV1[] counters, int type, DateTime fromTime, DateTime toTime, string timezone);
    }
}
