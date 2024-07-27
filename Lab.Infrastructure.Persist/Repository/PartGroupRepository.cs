using Ex.Domain.PartGroupAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class PartGroupRepository : BaseRepository<long, PartGroup>, IPartGroupRepository
    {
        private readonly LaboratoryCommandContext _context;

        public PartGroupRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
