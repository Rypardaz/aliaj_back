using AM.Domain.ProjectDossierCostBeforImplementationAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class ProjectDossierCostBeforImplementationRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, ProjectDossierCostBeforImplementation>(aliajCommandContext), IProjectDossierCostBeforImplementationRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
