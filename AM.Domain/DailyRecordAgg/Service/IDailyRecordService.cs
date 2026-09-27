using AM.Application.Contracts.DailyRecord;
using PhoenixFramework.Core;

namespace AM.Domain.DailyRecordAgg.Service;

public interface IDailyRecordService : IDomainService
{
    void SetDetails(DailyRecord dailyRecord, List<DailyRecordDetailOperations> details);
}