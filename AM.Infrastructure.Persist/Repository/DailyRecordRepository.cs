using AM.Domain.DailyRecordAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class DailyRecordRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, DailyRecord>(aliajCommandContext), IDailyRecordRepository;