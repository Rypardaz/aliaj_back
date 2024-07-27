using Ex.Application.Contracts.WireTypeGroup;
using Lab.Presentation.Facade.Contract.WireTypeGroup;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class WireTypeGroupCommandFacade : IWireTypeGroupCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public WireTypeGroupCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreateWireTypeGroup command)
        {
            return _responsiveCommandBus.Dispatch<CreateWireTypeGroup, Guid>(command);
        }

        public void Edit(EditWireTypeGroup command)
        {
            _commandBus.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivateWireTypeGroup(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivateWireTypeGroup(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemoveWireTypeGroup(guid);
            _commandBus.Dispatch(com);
        }
    }
}