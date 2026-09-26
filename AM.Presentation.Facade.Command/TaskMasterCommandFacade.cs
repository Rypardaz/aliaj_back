using Ex.Application.Contracts.TaskMaster;
using Lab.Presentation.Facade.Contract.TaskMaster;
using PhoenixFramework.Application.Command;

namespace Lab.Presentation.Facade.Command;

public class TaskMasterCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : ITaskMasterCommandFacade
{
    public Guid Create(CreateTaskMaster command)
    {
        return responsiveCommandBus.Dispatch<CreateTaskMaster, Guid>(command);
    }

    public void Edit(EditTaskMaster command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateTaskMaster(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateTaskMaster(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveTaskMaster(guid);
        commandBus.Dispatch(com);
    }
}