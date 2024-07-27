using Ex.Domain.PartAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class PartRepository : BaseRepository<long, Part>, IPartRepository
    {
        private readonly LaboratoryCommandContext _context;

        public PartRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
