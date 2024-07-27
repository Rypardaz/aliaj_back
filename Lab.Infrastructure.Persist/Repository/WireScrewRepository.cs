using Ex.Domain.WireScrewAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class WireScrewRepository : BaseRepository<long, WireScrew>, IWireScrewRepository
    {
        private readonly LaboratoryCommandContext _context;

        public WireScrewRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
