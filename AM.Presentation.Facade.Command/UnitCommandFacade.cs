using AM.Application.Contracts.Unit;
using AM.Presentation.Facade.Contract.Unit;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class UnitCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IUnitCommandFacade
{
    public Guid Create(CreateUnit command)
    {
        return responsiveCommandBus.Dispatch<CreateUnit, Guid>(command);
    }

    public void Edit(EditUnit command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateUnit(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateUnit(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveUnit(guid);
        commandBus.Dispatch(com);
    }
}