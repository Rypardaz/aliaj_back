using Ex.Application.Contracts.WireScrew;
using Lab.Presentation.Facade.Contract.WireScrew;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class WireScrewCommandFacade : IWireScrewCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public WireScrewCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreateWireScrew command)
        {
            return _responsiveCommandBus.Dispatch<CreateWireScrew, Guid>(command);
        }

        public void Edit(EditWireScrew command)
        {
            _commandBus.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivateWireScrew(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivateWireScrew(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemoveWireScrew(guid);
            _commandBus.Dispatch(com);
        }
    }
}
