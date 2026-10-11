using AM.Domain.ProjectDossierInvoiceAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class ProjectDossierInvoiceRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, ProjectDossierInvoice>(aliajCommandContext), IProjectDossierInvoiceRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
