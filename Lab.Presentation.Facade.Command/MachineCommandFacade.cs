using Ex.Application.Contracts.Machine;
using Lab.Presentation.Facade.Contract.Machine;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class MachineCommandFacade : IMachineCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public MachineCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreateMachine command)
        {
            return _responsiveCommandBus.Dispatch<CreateMachine, Guid>(command);
        }

        public void Edit(EditMachine command)
        {
            _commandBus.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivateMachine(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivateMachine(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemoveMachine(guid);
            _commandBus.Dispatch(com);
        }
    }
}
