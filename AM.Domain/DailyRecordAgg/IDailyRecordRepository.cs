using PhoenixFramework.Domain;

namespace AM.Domain.DailyRecordAgg;

public interface IDailyRecordRepository : IRepository<long, DailyRecord>
{

}