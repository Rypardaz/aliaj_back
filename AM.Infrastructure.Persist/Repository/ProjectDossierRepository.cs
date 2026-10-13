using AM.Domain.ProjectDossierAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class ProjectDossierRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, ProjectDossier>(aliajCommandContext), IProjectDossierRepository
{
}