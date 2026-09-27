using AM.Application.Contracts.GasTypeGroup;
using AM.Presentation.Facade.Contract.GasTypeGroup;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class GasTypeGroupCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IGasTypeGroupCommandFacade
{
    public Guid Create(CreateGasTypeGroup command)
    {
        return responsiveCommandBus.Dispatch<CreateGasTypeGroup, Guid>(command);
    }

    public void Edit(EditGasTypeGroup command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateGasTypeGroup(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateGasTypeGroup(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveGasTypeGroup(guid);
        commandBus.Dispatch(com);
    }
}