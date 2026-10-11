using AM.Application.Contracts.ProjectDossierInvoice;
using AM.Presentation.Facade.Contract.ProjectDossierInvoice;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class ProjectDossierInvoiceCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IProjectDossierInvoiceCommandFacade
{
    public Guid Create(CreateProjectDossierInvoice command)
    {
        return responsiveCommandBus.Dispatch<CreateProjectDossierInvoice, Guid>(command);
    }

    public void Edit(EditProjectDossierInvoice command)
    {
        commandBus.Dispatch(command);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveProjectDossierInvoice(guid);
        commandBus.Dispatch(com);
    }
}
