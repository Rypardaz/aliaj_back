using AM.Domain.ProjectAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class ProjectRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, Project>(aliajCommandContext), IProjectRepository
{
    public long DetailIdBy(Guid detailGuid)
    {
        return aliajCommandContext.ProjectDetails
            .Where(x => x.Guid == detailGuid)
            .Select(x => x.Id)
            .First();
    }
}