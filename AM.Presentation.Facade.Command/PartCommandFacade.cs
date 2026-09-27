using AM.Application.Contracts.Part;
using AM.Presentation.Facade.Contract.Part;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class PartCommandFacade(
    ICommandBus commandBus,
    IResponsiveCommandBus responsiveCommandBus,
    IResponsiveCommandBusAsync responsiveCommandBusAsync,
    ICommandBusAsync commandBusAsync)
    : IPartCommandFacade
{
    private readonly IResponsiveCommandBus _responsiveCommandBus = responsiveCommandBus;

    public async Task<Guid> Create(CreatePart command)
    {
        return await responsiveCommandBusAsync.Dispatch<CreatePart, Guid>(command);
    }

    public async Task Edit(EditPart command)
    {
        await commandBusAsync.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivatePart(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivatePart(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemovePart(guid);
        commandBus.Dispatch(com);
    }
}