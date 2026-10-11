using AM.Application.Contracts.ProjectDossierInvoice;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectDossierInvoice;

public interface IProjectDossierInvoiceCommandFacade : IFacadeService
{

    Guid Create(CreateProjectDossierInvoice command);

    void Edit(EditProjectDossierInvoice command);

    void Delete(Guid guid);
}
