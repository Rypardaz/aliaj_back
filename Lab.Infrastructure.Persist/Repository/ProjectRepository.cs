using Ex.Domain.ProjectAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class ProjectRepository : BaseRepository<long, Project>, IProjectRepository
    {
        private readonly LaboratoryCommandContext _context;

        public ProjectRepository(LaboratoryCommandContext commandContext) : base(commandContext)
        {
            _context = commandContext;
        }

        public long DetailIdBy(Guid detailGuid)
        {
            return _context.ProjectDetails
                .Where(x => x.Guid == detailGuid)
                .Select(x => x.Id)
                .First();
        }
    }
}
