using AM.Application.Contracts.ProjectDossierCost;
using AM.Presentation.Facade.Contract.ProjectDossierCost;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class ProjectDossierCostCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IProjectDossierCostCommandFacade
{
    public Guid Create(CreateProjectDossierCost command)
    {
        return responsiveCommandBus.Dispatch<CreateProjectDossierCost, Guid>(command);
    }

    public void Edit(EditProjectDossierCost command)
    {
        commandBus.Dispatch(command);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveProjectDossierCost(guid);
        commandBus.Dispatch(com);
    }
}
