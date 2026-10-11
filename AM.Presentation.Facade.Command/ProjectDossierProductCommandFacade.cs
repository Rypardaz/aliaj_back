using AM.Application.Contracts.ProjectDossierProduct;
using AM.Presentation.Facade.Contract.ProjectDossierProduct;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class ProjectDossierProductCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IProjectDossierProductCommandFacade
{
    public Guid Create(CreateProjectDossierProduct command)
    {
        return responsiveCommandBus.Dispatch<CreateProjectDossierProduct, Guid>(command);
    }

    public void Edit(EditProjectDossierProduct command)
    {
        commandBus.Dispatch(command);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveProjectDossierProduct(guid);
        commandBus.Dispatch(com);
    }
}
