using AM.Domain.ProjectDossierDepositAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class ProjectDossierDepositRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, ProjectDossierDeposit>(aliajCommandContext), IProjectDossierDepositRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
