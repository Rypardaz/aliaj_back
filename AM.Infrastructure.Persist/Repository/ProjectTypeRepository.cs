using AM.Domain.ProjectTypeAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class ProjectTypeRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, ProjectType>(aliajCommandContext), IProjectTypeRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}