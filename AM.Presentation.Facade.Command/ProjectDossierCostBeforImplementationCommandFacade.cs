using AM.Application.Contracts.ProjectDossierCostBeforImplementation;
using AM.Presentation.Facade.Contract.ProjectDossierCostBeforImplementation;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class ProjectDossierCostBeforImplementationCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IProjectDossierCostBeforImplementationCommandFacade
{
    public Guid Create(CreateProjectDossierCostBeforImplementation command)
    {
        return responsiveCommandBus.Dispatch<CreateProjectDossierCostBeforImplementation, Guid>(command);
    }

    public void Edit(EditProjectDossierCostBeforImplementation command)
    {
        commandBus.Dispatch(command);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveProjectDossierCostBeforImplementation(guid);
        commandBus.Dispatch(com);
    }
}
