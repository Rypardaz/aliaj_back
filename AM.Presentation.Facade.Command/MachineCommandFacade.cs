using AM.Application.Contracts.Machine;
using AM.Presentation.Facade.Contract.Machine;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class MachineCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IMachineCommandFacade
{
    public Guid Create(CreateMachine command)
    {
        return responsiveCommandBus.Dispatch<CreateMachine, Guid>(command);
    }

    public void Edit(EditMachine command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateMachine(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateMachine(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveMachine(guid);
        commandBus.Dispatch(com);
    }
}