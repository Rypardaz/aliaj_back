using AM.Application.Contracts.ProjectDossierDeposit;
using AM.Presentation.Facade.Contract.ProjectDossierDeposit;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class ProjectDossierDepositCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IProjectDossierDepositCommandFacade
{
    public Guid Create(CreateProjectDossierDeposit command)
    {
        return responsiveCommandBus.Dispatch<CreateProjectDossierDeposit, Guid>(command);
    }

    public void Edit(EditProjectDossierDeposit command)
    {
        commandBus.Dispatch(command);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveProjectDossierDeposit(guid);
        commandBus.Dispatch(com);
    }
}
