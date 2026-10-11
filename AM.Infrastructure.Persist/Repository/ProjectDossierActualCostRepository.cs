using AM.Domain.ProjectDossierActualCostAdd;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class ProjectDossierActualCostRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, ProjectDossierActualCost>(aliajCommandContext), IProjectDossierActualCostRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
