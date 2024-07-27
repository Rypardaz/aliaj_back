using Ex.Domain.SalonAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class SalonRepository : BaseRepository<long, Salon>, ISalonRepository
    {
        private readonly LaboratoryCommandContext _context;

        public SalonRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
