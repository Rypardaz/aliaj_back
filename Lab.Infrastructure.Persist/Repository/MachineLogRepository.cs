using Ex.Domain.MachineLogAgg;
using Microsoft.EntityFrameworkCore;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class MachineLogRepository : BaseRepository<long, MachineLog>, IMachineLogRepository
    {
        public MachineLogRepository(LaboratoryCommandContext context) : base(context)
        {
        }
    }
}
