using Ex.Domain.TaskMasterAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class TaskMasterRepository : BaseRepository<long, TaskMaster>, ITaskMasterRepository
    {
        private readonly LaboratoryCommandContext _context;

        public TaskMasterRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
