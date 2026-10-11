using AM.Application.Contracts.ProjectDossierInvoice;
using AM.Infrastructure.Query.Contract.ProjectDossierInvoice;
using AM.Presentation.Facade.Contract.ProjectDossierInvoice;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class ProjectDossierInvoiceQueryFacade(IQueryBus queryBus) : IProjectDossierInvoiceQueryFacade
{
    public List<ProjectDossierInvoiceViewModel> List() => queryBus.Dispatch<List<ProjectDossierInvoiceViewModel>>();
    public EditProjectDossierInvoice GetDetails(Guid guid) => queryBus.Dispatch<EditProjectDossierInvoice, Guid>(guid);
}
