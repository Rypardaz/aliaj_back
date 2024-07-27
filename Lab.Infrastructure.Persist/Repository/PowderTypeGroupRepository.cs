using Ex.Domain.PowderTypeGroupAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class PowderTypeGroupRepository : BaseRepository<long, PowderTypeGroup>, IPowderTypeGroupRepository
    {
        private readonly LaboratoryCommandContext _context;

        public PowderTypeGroupRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
