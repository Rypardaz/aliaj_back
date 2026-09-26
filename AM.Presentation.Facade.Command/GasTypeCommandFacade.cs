using Ex.Application.Contracts.GasType;
using Lab.Presentation.Facade.Contract.GasType;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command;

public class GasTypeCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IGasTypeCommandFacade
{
    public Guid Create(CreateGasType command)
    {
        return responsiveCommandBus.Dispatch<CreateGasType, Guid>(command);
    }

    public void Edit(EditGasType command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateGasType(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateGasType(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveGasType(guid);
        commandBus.Dispatch(com);
    }
}