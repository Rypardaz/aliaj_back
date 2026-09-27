using AM.Application.Contracts.TaskMaster;
using AM.Domain.TaskMasterAgg;
using AM.Domain.TaskMasterAgg.Service;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class TaskMasterCommandHandler(
    IClaimHelper claimHelper,
    ITaskMasterRepository taskMasterRepository,
    ITaskMasterService taskMasterService)
    :
        ICommandHandler<CreateTaskMaster, Guid>,
        ICommandHandler<EditTaskMaster>,
        ICommandHandler<RemoveTaskMaster>,
        ICommandHandler<ActivateTaskMaster>,
        ICommandHandler<DeactivateTaskMaster>
{
    public Guid Handle(CreateTaskMaster command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var taskMaster = new TaskMaster(creator, command.Name, taskMasterService);
        taskMasterRepository.Create(taskMaster);
        return taskMaster.Guid;
    }

    public void Handle(EditTaskMaster command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var taskMaster = taskMasterRepository.Load(command.Guid);
        taskMaster.Edit(actor, command.Name, taskMasterService);
    }

    public void Handle(RemoveTaskMaster command)
    {
        var taskMaster = taskMasterRepository.Load(command.Guid);
        taskMasterRepository.Delete(taskMaster);
    }
    public void Handle(ActivateTaskMaster command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var taskMaster = taskMasterRepository.Load(command.Guid);
        taskMaster.Activate();
    }

    public void Handle(DeactivateTaskMaster command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var taskMaster = taskMasterRepository.Load(command.Guid);
        taskMaster.Deactivate();
    }
}