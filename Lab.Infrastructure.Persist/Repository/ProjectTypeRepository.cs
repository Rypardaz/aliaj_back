using Ex.Domain.ProjectTypeAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class ProjectTypeRepository : BaseRepository<long, ProjectType>, IProjectTypeRepository
    {
        private readonly LaboratoryCommandContext _context;

        public ProjectTypeRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }
    }
}
