using Ex.Domain.ProjectAgg;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Project;
using PhoenixFramework.Application.Command;
using Ex.Domain.ProjectAgg.Service;
using Ex.Domain.TaskMasterAgg;
using Ex.Domain.SalonAgg;
using Ex.Domain.ProjectTypeAgg;
using Ex.Domain.ListItemAgg;
using Ex.Domain.WireTypeAgg;
using PhoenixFramework.Core.Exceptions;

namespace Ex.Application;

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
    private readonly IWireTypeRepository _wireTypeRepository;

    public ProjectCommandHandler(IClaimHelper claimHelper, IProjectRepository projectRepository,
        IProjectService projectService,
        ITaskMasterRepository taskMasterRepository, ISalonRepository salonRepository,
        IProjectTypeRepository projectTypeRepository, IListItemRepository listItemRepository,
        IWireTypeRepository wireTypeRepository)
    {
        _claimHelper = claimHelper;
        _projectRepository = projectRepository;
        _projectService = projectService;
        _taskMasterRepository = taskMasterRepository;
        _salonRepository = salonRepository;
        _projectTypeRepository = projectTypeRepository;
        _listItemRepository = listItemRepository;
        _wireTypeRepository = wireTypeRepository;
    }

    public Guid Handle(CreateProject command)
    {
        var creator = _claimHelper.GetCurrentUserGuid();

        if (_projectRepository.Exists(x => x.Code.ToLower() == command.Code.ToLower()))
            throw new BusinessException("0", "کد پروژه تکراری است.");

        if (_projectRepository.Exists(x => x.Name == command.Name))
            throw new BusinessException("0", "نام پروژه تکراری است.");

        var taskMasterGuid = _taskMasterRepository.GetIdBy(command.TaskMasterGuid);
        var salonGuid = _salonRepository.GetIdBy(command.SalonGuid);
        var projectTypeId = _projectTypeRepository.GetIdBy(command.ProjectTypeGuid);
        var isActive = _listItemRepository.GetIdBy(command.IsActive);

        long? replacementWireTypeId = null;

        if (command.ReplacementWireTypeGuid is not null)
            replacementWireTypeId = _wireTypeRepository.GetIdBy(command.ReplacementWireTypeGuid.Value);

        var project = new Project(creator, command.Code, command.Name, taskMasterGuid, projectTypeId,
            salonGuid, command.DeliveryDate, isActive, command.Description, replacementWireTypeId,
            _projectService);

        _projectService.SetDetails(project, command.Details);

        _projectRepository.Create(project);
        return project.Guid;
    }

    public void Handle(EditProject command)
    {
        var actor = _claimHelper.GetCurrentUserGuid();
        var project = _projectRepository.Load(command.Guid, "Details");

        if (_projectRepository.Exists(x => x.Code.ToLower() == command.Code.ToLower() && x.Guid != command.Guid))
            throw new BusinessException("0", "کد پروژه تکراری است.");

        if (_projectRepository.Exists(x => x.Name == command.Name && x.Guid != command.Guid))
            throw new BusinessException("0", "نام پروژه تکراری است.");

        var taskMasterGuid = _taskMasterRepository.GetIdBy(command.TaskMasterGuid);
        var salonGuid = _salonRepository.GetIdBy(command.SalonGuid);
        var projectTypeId = _projectTypeRepository.GetIdBy(command.ProjectTypeGuid);
        var isActive = _listItemRepository.GetIdBy(command.IsActive);

        long? replacementWireTypeId = null;

        if (command.ReplacementWireTypeGuid is not null)
            replacementWireTypeId = _wireTypeRepository.GetIdBy(command.ReplacementWireTypeGuid.Value);

        project.Edit(actor, command.Code, command.Name, taskMasterGuid, projectTypeId, salonGuid,
            command.DeliveryDate, isActive, command.Description, replacementWireTypeId, _projectService);

        _projectService.SetDetails(project, command.Details);
    }

    public void Handle(RemoveProject command)
    {
        var project = _projectRepository.Load(command.Guid);

        _projectRepository.Delete(project);
    }
}