using Ex.Application.Contracts.MachineLog;
using Lab.Presentation.Facade.Contract.MachineLog;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class MachineLogCommandFacade : IMachineLogCommandFacade
    {
        private readonly ICommandBus _commandBus;

        public MachineLogCommandFacade(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public void Create(CreateMachineLog command)
        {
            _commandBus.Dispatch(command);
        }
    }
}