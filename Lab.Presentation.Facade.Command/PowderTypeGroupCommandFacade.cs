using Ex.Application.Contracts.PowderTypeGroup;
using Lab.Presentation.Facade.Contract.PowderTypeGroup;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class PowderTypeGroupCommandFacade : IPowderTypeGroupCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public PowderTypeGroupCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreatePowderTypeGroup command)
        {
            return _responsiveCommandBus.Dispatch<CreatePowderTypeGroup, Guid>(command);
        }

        public void Edit(EditPowderTypeGroup command)
        {
            _commandBus.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivatePowderTypeGroup(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivatePowderTypeGroup(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemovePowderTypeGroup(guid);
            _commandBus.Dispatch(com);
        }
    }
}