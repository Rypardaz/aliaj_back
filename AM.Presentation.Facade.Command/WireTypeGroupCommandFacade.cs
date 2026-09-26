using Ex.Application.Contracts.WireTypeGroup;
using Lab.Presentation.Facade.Contract.WireTypeGroup;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command;

public class WireTypeGroupCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IWireTypeGroupCommandFacade
{
    public Guid Create(CreateWireTypeGroup command)
    {
        return responsiveCommandBus.Dispatch<CreateWireTypeGroup, Guid>(command);
    }

    public void Edit(EditWireTypeGroup command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateWireTypeGroup(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateWireTypeGroup(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveWireTypeGroup(guid);
        commandBus.Dispatch(com);
    }
}