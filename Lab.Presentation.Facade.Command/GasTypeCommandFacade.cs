using Ex.Application.Contracts.GasType;
using Lab.Presentation.Facade.Contract.GasType;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class GasTypeCommandFacade : IGasTypeCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public GasTypeCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreateGasType command)
        {
            return _responsiveCommandBus.Dispatch<CreateGasType, Guid>(command);
        }

        public void Edit(EditGasType command)
        {
            _commandBus.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivateGasType(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivateGasType(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemoveGasType(guid);
            _commandBus.Dispatch(com);
        }
    }
}
