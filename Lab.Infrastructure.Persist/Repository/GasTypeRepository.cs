using Ex.Domain.GasTypeAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class GasTypeRepository : BaseRepository<long, GasType>, IGasTypeRepository
    {
        private readonly LaboratoryCommandContext _context;

        public GasTypeRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
