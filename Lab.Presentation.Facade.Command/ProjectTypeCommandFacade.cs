using Ex.Application.Contracts.ProjectType;
using Lab.Presentation.Facade.Contract.ProjectType;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command
{
    public class ProjectTypeCommandFacade : IProjectTypeCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly ICommandBusAsync _commandBusAsync;
        private readonly IResponsiveCommandBus _responsiveCommandBus;
        private readonly IResponsiveCommandBusAsync _responsiveCommandBusAsync;

        public ProjectTypeCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus, IResponsiveCommandBusAsync responsiveCommandBusAsync, ICommandBusAsync commandBusAsync)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
            _responsiveCommandBusAsync = responsiveCommandBusAsync;
            _commandBusAsync = commandBusAsync;
        }

        public async Task<Guid> Create(CreateProjectType command)
        {
            return await _responsiveCommandBusAsync.Dispatch<CreateProjectType, Guid>(command);
        }

        public async Task Edit(EditProjectType command)
        {
            await _commandBusAsync.Dispatch(command);
        }

        public void Deactivate(Guid guid)
        {
            var com = new DeactivateProjectType(guid);
            _commandBus.Dispatch(com);
        }

        public void Activate(Guid guid)
        {
            var com = new ActivateProjectType(guid);
            _commandBus.Dispatch(com);
        }

        public void Delete(Guid guid)
        {
            var com = new RemoveProjectType(guid);
            _commandBus.Dispatch(com);
        }
    }
}