using Ex.Application.Contracts.Part;
using Lab.Presentation.Facade.Contract.Part;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class PartCommandFacade : IPartCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly ICommandBusAsync _commandBusAsync;
        private readonly IResponsiveCommandBus _responsiveCommandBus;
        private readonly IResponsiveCommandBusAsync _responsiveCommandBusAsync;

        public PartCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus, IResponsiveCommandBusAsync responsiveCommandBusAsync, ICommandBusAsync commandBusAsync)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
            _responsiveCommandBusAsync = responsiveCommandBusAsync;
            _commandBusAsync = commandBusAsync;
        }

        public async Task<Guid> Create(CreatePart command)
        {
            return await _responsiveCommandBusAsync.Dispatch<CreatePart, Guid>(command);
        }

        public async Task Edit(EditPart command)
        {
            await _commandBusAsync.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivatePart(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivatePart(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemovePart(guid);
            _commandBus.Dispatch(com);
        }
    }
}