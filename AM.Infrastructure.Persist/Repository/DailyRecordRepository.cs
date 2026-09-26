using Ex.Domain.DailyRecordAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class DailyRecordRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, DailyRecord>(aliajCommandContext), IDailyRecordRepository;