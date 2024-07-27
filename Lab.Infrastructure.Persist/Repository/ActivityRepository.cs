using Ex.Domain.ActivityAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class ActivityRepository : BaseRepository<long, Activity>, IActivityRepository
    {
        private readonly LaboratoryCommandContext _context;

        public ActivityRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
