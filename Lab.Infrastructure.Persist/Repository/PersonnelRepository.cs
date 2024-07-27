using Ex.Domain.PersonnelAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class PersonnelRepository : BaseRepository<long, Personnel>, IPersonnelRepository
    {
        private readonly LaboratoryCommandContext _context;

        public PersonnelRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
