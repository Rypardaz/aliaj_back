using AM.Application.Contracts.PowderType;
using AM.Presentation.Facade.Contract.PowderType;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class PowderTypeCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IPowderTypeCommandFacade
{
    public Guid Create(CreatePowderType command)
    {
        return responsiveCommandBus.Dispatch<CreatePowderType, Guid>(command);
    }

    public void Edit(EditPowderType command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivatePowderType(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivatePowderType(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemovePowderType(guid);
        commandBus.Dispatch(com);
    }
}