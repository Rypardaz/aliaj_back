using Ex.Domain.ProjectTypeAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class ProjectTypeRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, ProjectType>(aliajCommandContext), IProjectTypeRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}