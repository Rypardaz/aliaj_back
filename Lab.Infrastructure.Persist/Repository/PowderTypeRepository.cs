using Ex.Domain.PowderTypeAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class PowderTypeRepository : BaseRepository<long, PowderType>, IPowderTypeRepository
    {
        private readonly LaboratoryCommandContext _context;

        public PowderTypeRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
