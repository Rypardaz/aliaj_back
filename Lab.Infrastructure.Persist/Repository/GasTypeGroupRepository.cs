using Ex.Domain.GasTypeGroupAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class GasTypeGroupRepository : BaseRepository<long, GasTypeGroup>, IGasTypeGroupRepository
    {
        private readonly LaboratoryCommandContext _context;

        public GasTypeGroupRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
