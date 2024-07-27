using Ex.Application.Contracts.PowderType;
using Lab.Presentation.Facade.Contract.PowderType;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class PowderTypeCommandFacade : IPowderTypeCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public PowderTypeCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreatePowderType command)
        {
            return _responsiveCommandBus.Dispatch<CreatePowderType, Guid>(command);
        }

        public void Edit(EditPowderType command)
        {
            _commandBus.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivatePowderType(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivatePowderType(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemovePowderType(guid);
            _commandBus.Dispatch(com);
        }
    }
}
