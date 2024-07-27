using Ex.Application.Contracts.Project;
using PhoenixFramework.Application.Command;
using Lab.Presentation.Facade.Contract.Project;

namespace Lab.Presentation.Facade.Command
{
    public class ProjectCommandFacade : IProjectCommandFacade
    {
        private readonly ICommandBus _commandBus;
        private readonly IResponsiveCommandBus _responsiveCommandBus;

        public ProjectCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
        {
            _commandBus = commandBus;
            _responsiveCommandBus = responsiveCommandBus;
        }

        public Guid Create(CreateProject command) => _responsiveCommandBus.Dispatch<CreateProject, Guid>(command);

        public void Edit(EditProject command) => _commandBus.Dispatch(command);

        public void Delete(Guid guid)
        {
            var com = new RemoveProject(guid);
            _commandBus.Dispatch(com);
        }
    }
}
