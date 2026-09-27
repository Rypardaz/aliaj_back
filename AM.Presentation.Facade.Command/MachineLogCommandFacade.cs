using AM.Application.Contracts.MachineLog;
using AM.Presentation.Facade.Contract.MachineLog;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class MachineLogCommandFacade(ICommandBus commandBus) : IMachineLogCommandFacade
{
    public void Create(CreateMachineLog command)
    {
        commandBus.Dispatch(command);
    }
}