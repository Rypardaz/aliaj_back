using Ex.Application.Contracts.Personnel;
using Lab.Presentation.Facade.Contract.Personnel;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class PersonnelCommandFacade : IPersonnelCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly ICommandBusAsync _commandBusAsync;
        private readonly IResponsiveCommandBus _responsiveCommandBus;
        private readonly IResponsiveCommandBusAsync _responsiveCommandBusAsync;

        public PersonnelCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus, IResponsiveCommandBusAsync responsiveCommandBusAsync, ICommandBusAsync commandBusAsync)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
            _responsiveCommandBusAsync = responsiveCommandBusAsync;
            _commandBusAsync = commandBusAsync;
        }

        public async Task<Guid> Create(CreatePersonnel command)
        {
            return await _responsiveCommandBusAsync.Dispatch<CreatePersonnel, Guid>(command);
        }

        public async Task Edit(EditPersonnel command)
        {
            await _commandBusAsync.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivatePersonnel(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivatePersonnel(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemovePersonnel(guid);
            _commandBus.Dispatch(com);
        }
    }
}