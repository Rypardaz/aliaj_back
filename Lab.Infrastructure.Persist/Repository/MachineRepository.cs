using Ex.Domain.MachineAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class MachineRepository : BaseRepository<long, Machine>, IMachineRepository
    {
        private readonly LaboratoryCommandContext _context;

        public MachineRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }

        public long GetIdBy(string code)
        {
            return _context.Machine
                .Select(x => new { x.Id, x.Code })
                .First(x => x.Code == code)
                .Id;
        }
    }
}
