using AM.Application.Contracts.WireScrew;
using AM.Presentation.Facade.Contract.WireScrew;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class WireScrewCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IWireScrewCommandFacade
{
    public Guid Create(CreateWireScrew command)
    {
        return responsiveCommandBus.Dispatch<CreateWireScrew, Guid>(command);
    }

    public void Edit(EditWireScrew command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateWireScrew(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateWireScrew(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveWireScrew(guid);
        commandBus.Dispatch(com);
    }
}