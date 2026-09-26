using Ex.Application.Contracts.PowderTypeGroup;
using Lab.Presentation.Facade.Contract.PowderTypeGroup;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command;

public class PowderTypeGroupCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IPowderTypeGroupCommandFacade
{
    public Guid Create(CreatePowderTypeGroup command)
    {
        return responsiveCommandBus.Dispatch<CreatePowderTypeGroup, Guid>(command);
    }

    public void Edit(EditPowderTypeGroup command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivatePowderTypeGroup(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivatePowderTypeGroup(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemovePowderTypeGroup(guid);
        commandBus.Dispatch(com);
    }
}