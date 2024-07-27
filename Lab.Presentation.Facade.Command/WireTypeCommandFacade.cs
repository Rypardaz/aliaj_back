using Ex.Application.Contracts.WireType;
using Lab.Presentation.Facade.Contract.WireType;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class WireTypeCommandFacade : IWireTypeCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public WireTypeCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreateWireType command)
        {
            return _responsiveCommandBus.Dispatch<CreateWireType, Guid>(command);
        }

        public void Edit(EditWireType command)
        {
            _commandBus.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivateWireType(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivateWireType(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemoveWireType(guid);
            _commandBus.Dispatch(com);
        }
    }
}
