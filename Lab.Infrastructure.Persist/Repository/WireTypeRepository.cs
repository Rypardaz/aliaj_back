using Ex.Domain.WireTypeAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class WireTypeRepository : BaseRepository<long, WireType>, IWireTypeRepository
    {
        private readonly LaboratoryCommandContext _context;

        public WireTypeRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
