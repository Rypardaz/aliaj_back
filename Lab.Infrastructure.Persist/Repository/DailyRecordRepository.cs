using Ex.Domain.DailyRecordAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class DailyRecordRepository : BaseRepository<long, DailyRecord>, IDailyRecordRepository
    {
        public DailyRecordRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
        }
    }
}