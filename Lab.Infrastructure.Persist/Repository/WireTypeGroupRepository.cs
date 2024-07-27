using Ex.Domain.WireTypeGroupAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class WireTypeGroupRepository : BaseRepository<long, WireTypeGroup>, IWireTypeGroupRepository
    {
        private readonly LaboratoryCommandContext _context;

        public WireTypeGroupRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
