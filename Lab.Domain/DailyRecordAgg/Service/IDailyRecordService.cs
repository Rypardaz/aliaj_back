using Ex.Application.Contracts.DailyRecord;
using PhoenixFramework.Core;

namespace Ex.Domain.DailyRecordAgg.Service
{
    public interface IDailyRecordService : IDomainService
    {
        void SetDetails(DailyRecord dailyRecord, List<DailyRecordDetailOperations> details);
    }
}
