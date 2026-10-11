using AM.Application.Contracts.ProjectDossierInvoice;
using AM.Infrastructure.Query.Contract.ProjectDossierInvoice;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectDossierInvoice;

public interface IProjectDossierInvoiceQueryFacade : IFacadeService
{
    List<ProjectDossierInvoiceViewModel> List();

    EditProjectDossierInvoice GetDetails(Guid guid);
}