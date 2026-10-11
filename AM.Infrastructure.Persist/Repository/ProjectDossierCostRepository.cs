using AM.Domain.ProjectDossierCostAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class ProjectDossierCostRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, ProjectDossierCost>(aliajCommandContext), IProjectDossierCostRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
