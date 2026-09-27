using AM.Application.Contracts.Project;
using AM.Presentation.Facade.Contract.Project;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class ProjectCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IProjectCommandFacade
{
    public Guid Create(CreateProject command) => responsiveCommandBus.Dispatch<CreateProject, Guid>(command);

    public void Edit(EditProject command) => commandBus.Dispatch(command);

    public void Delete(Guid guid)
    {
        var com = new RemoveProject(guid);
        commandBus.Dispatch(com);
    }
}