using AM.Application.Contracts.ProjectDossierActualCost;
using AM.Presentation.Facade.Contract.ProjectDossierActualCost;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class ProjectDossierActualCostCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IProjectDossierActualCostCommandFacade
{
    public Guid Create(CreateProjectDossierActualCost command)
    {
        return responsiveCommandBus.Dispatch<CreateProjectDossierActualCost, Guid>(command);
    }

    public void Edit(EditProjectDossierActualCost command)
    {
        commandBus.Dispatch(command);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveProjectDossierActualCost(guid);
        commandBus.Dispatch(com);
    }
}
