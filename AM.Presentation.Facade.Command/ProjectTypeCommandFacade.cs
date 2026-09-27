using AM.Application.Contracts.ProjectType;
using AM.Presentation.Facade.Contract.ProjectType;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class ProjectTypeCommandFacade(
    ICommandBus commandBus,
    IResponsiveCommandBus responsiveCommandBus,
    IResponsiveCommandBusAsync responsiveCommandBusAsync,
    ICommandBusAsync commandBusAsync)
    : IProjectTypeCommandFacade
{
    private readonly IResponsiveCommandBus _responsiveCommandBus = responsiveCommandBus;

    public async Task<Guid> Create(CreateProjectType command)
    {
        return await responsiveCommandBusAsync.Dispatch<CreateProjectType, Guid>(command);
    }

    public async Task Edit(EditProjectType command)
    {
        await commandBusAsync.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateProjectType(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateProjectType(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveProjectType(guid);
        commandBus.Dispatch(com);
    }
}