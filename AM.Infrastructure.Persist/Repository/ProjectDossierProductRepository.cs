using AM.Domain.ProjectDossierProductAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class ProjectDossierProductRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, ProjectDossierProduct>(aliajCommandContext), IProjectDossierProductRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
