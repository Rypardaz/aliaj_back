using Ex.Application.Contracts.MachineLog;
using Lab.Presentation.Facade.Contract.MachineLog;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command;

public class MachineLogCommandFacade(ICommandBus commandBus) : IMachineLogCommandFacade
{
    public void Create(CreateMachineLog command)
    {
        commandBus.Dispatch(command);
    }
}