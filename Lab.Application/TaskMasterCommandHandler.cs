using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.TaskMaster;
using Ex.Domain.TaskMasterAgg.Service;
using Ex.Domain.TaskMasterAgg;

namespace Ex.Application
{
    public class TaskMasterCommandHandler :
    ICommandHandler<CreateTaskMaster, Guid>,
    ICommandHandler<EditTaskMaster>,
    ICommandHandler<RemoveTaskMaster>,
    ICommandHandler<ActivateTaskMaster>,
    ICommandHandler<DeactivateTaskMaster>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly ITaskMasterRepository _taskMasterRepository;
        private readonly ITaskMasterService _taskMasterService;

        public TaskMasterCommandHandler(IClaimHelper claimHelper
            , ITaskMasterRepository taskMasterRepository
            , ITaskMasterService taskMasterService)
        {
            _claimHelper = claimHelper;
            _taskMasterRepository = taskMasterRepository;
            _taskMasterService = taskMasterService;
        }

        public Guid Handle(CreateTaskMaster command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var taskMaster = new TaskMaster(creator, command.Name, _taskMasterService);
            _taskMasterRepository.Create(taskMaster);
            return taskMaster.Guid;
        }

        public void Handle(EditTaskMaster command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var taskMaster = _taskMasterRepository.Load(command.Guid);
            taskMaster.Edit(actor, command.Name, _taskMasterService);
        }

        public void Handle(RemoveTaskMaster command)
        {
            var taskMaster = _taskMasterRepository.Load(command.Guid);
            _taskMasterRepository.Delete(taskMaster);
        }
        public void Handle(ActivateTaskMaster command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var taskMaster = _taskMasterRepository.Load(command.Guid);
            taskMaster.Activate();
        }

        public void Handle(DeactivateTaskMaster command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var taskMaster = _taskMasterRepository.Load(command.Guid);
            taskMaster.Deactivate();
        }
    }
}
