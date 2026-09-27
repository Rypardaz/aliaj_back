using AM.Application.Contracts.WireType;
using AM.Presentation.Facade.Contract.WireType;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class WireTypeCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IWireTypeCommandFacade
{
    public Guid Create(CreateWireType command)
    {
        return responsiveCommandBus.Dispatch<CreateWireType, Guid>(command);
    }

    public void Edit(EditWireType command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateWireType(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateWireType(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveWireType(guid);
        commandBus.Dispatch(com);
    }
}