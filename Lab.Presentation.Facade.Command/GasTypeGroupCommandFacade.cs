using Ex.Application.Contracts.GasTypeGroup;
using Lab.Presentation.Facade.Contract.GasTypeGroup;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class GasTypeGroupCommandFacade : IGasTypeGroupCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public GasTypeGroupCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreateGasTypeGroup command)
        {
            return _responsiveCommandBus.Dispatch<CreateGasTypeGroup, Guid>(command);
        }

        public void Edit(EditGasTypeGroup command)
        {
            _commandBus.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivateGasTypeGroup(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivateGasTypeGroup(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemoveGasTypeGroup(guid);
            _commandBus.Dispatch(com);
        }
    }
}