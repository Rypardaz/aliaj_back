using Ex.Domain.ProjectAgg;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Project;
using PhoenixFramework.Application.Command;
using Ex.Domain.ProjectAgg.Service;
using Ex.Domain.TaskMasterAgg;
using Ex.Domain.SalonAgg;
using Ex.Domain.ProjectTypeAgg;
using Ex.Domain.ListItemAgg;

namespace Ex.Application
{
    public class ProjectCommandHandler :
        ICommandHandler<CreateProject, Guid>,
        ICommandHandler<EditProject>,
        ICommandHandler<RemoveProject>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectService _projectService;
        private readonly ITaskMasterRepository _taskMasterRepository;
        private readonly ISalonRepository _salonRepository;
        private readonly IProjectTypeRepository _projectTypeRepository;
        private readonly IListItemRepository _listItemRepository;

        public ProjectCommandHandler(IClaimHelper claimHelper, IProjectRepository projectRepository, IProjectService projectService,
            ITaskMasterRepository taskMasterRepository, ISalonRepository salonRepository, IProjectTypeRepository projectTypeRepository, IListItemRepository listItemRepository)
        {
            _claimHelper = claimHelper;
            _projectRepository = projectRepository;
            _projectService = projectService;
            _taskMasterRepository = taskMasterRepository;
            _salonRepository = salonRepository;
            _projectTypeRepository = projectTypeRepository;
            _listItemRepository = listItemRepository;
        }

        public Guid Handle(CreateProject command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var taskMasterGuid = _taskMasterRepository.GetIdBy(command.TaskMasterGuid);
            var salonGuid = _salonRepository.GetIdBy(command.SalonGuid);
            var projectTypeId = _projectTypeRepository.GetIdBy(command.ProjectTypeGuid);
            var isActive = _listItemRepository.GetIdBy(command.IsActive);

            var project = new Project(creator, command.Code, command.Name, taskMasterGuid, projectTypeId,
                salonGuid, command.DeliveryDate, isActive, command.Description, _projectService);

            _projectService.SetDetails(project, command.Details);

            _projectRepository.Create(project);
            return project.Guid;
        }

        public void Handle(EditProject command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var project = _projectRepository.Load(command.Guid, "Details");

            var taskMasterGuid = _taskMasterRepository.GetIdBy(command.TaskMasterGuid);
            var salonGuid = _salonRepository.GetIdBy(command.SalonGuid);
            var projectTypeId = _projectTypeRepository.GetIdBy(command.ProjectTypeGuid);
            var isActive = _listItemRepository.GetIdBy(command.IsActive);

            project.Edit(actor, command.Code, command.Name, taskMasterGuid, projectTypeId, salonGuid,
                command.DeliveryDate, isActive, command.Description, _projectService);

            _projectService.SetDetails(project, command.Details);
        }

        public void Handle(RemoveProject command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var project = _projectRepository.Load(command.Guid);
            project.Remove(actor);
        }
    }
}
