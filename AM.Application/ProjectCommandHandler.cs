using AM.Application.Contracts.Project;
using AM.Domain.ListItemAgg;
using AM.Domain.ProjectAgg;
using AM.Domain.ProjectAgg.Service;
using AM.Domain.ProjectTypeAgg;
using AM.Domain.SalonAgg;
using AM.Domain.TaskMasterAgg;
using AM.Domain.WireTypeAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Identity;

namespace AM.Application;

public class ProjectCommandHandler(
    IClaimHelper claimHelper,
    IProjectRepository projectRepository,
    IProjectService projectService,
    ITaskMasterRepository taskMasterRepository,
    ISalonRepository salonRepository,
    IProjectTypeRepository projectTypeRepository,
    IListItemRepository listItemRepository,
    IWireTypeRepository wireTypeRepository)
    :
        ICommandHandler<CreateProject, Guid>,
        ICommandHandler<EditProject>,
        ICommandHandler<RemoveProject>
{
    public Guid Handle(CreateProject command)
    {
        var creator = claimHelper.GetCurrentUserGuid();

        if (projectRepository.Exists(x => x.Code.ToLower() == command.Code.ToLower()))
            throw new BusinessException("0", "کد پروژه تکراری است.");

        // if (_projectRepository.Exists(x => x.Name == command.Name))
        //     throw new BusinessException("0", "نام پروژه تکراری است.");

        var taskMasterGuid = taskMasterRepository.GetIdBy(command.TaskMasterGuid);
        var salonGuid = salonRepository.GetIdBy(command.SalonGuid);
        var projectTypeId = projectTypeRepository.GetIdBy(command.ProjectTypeGuid);
        var isActive = listItemRepository.GetIdBy(command.IsActive);

        var project = new Project(creator, command.Code, command.Name, taskMasterGuid, projectTypeId,
            salonGuid, command.DeliveryDate, isActive, command.Description, projectService);

        List<ProjectReplacementWireType>? replacementWireTypes = null;

        if (command.ReplacementWireTypeGuids is not null)
            replacementWireTypes = command.ReplacementWireTypeGuids
                .Select(x => new ProjectReplacementWireType(creator, project.Id, wireTypeRepository.GetIdBy(x)))
                .ToList();

        project.SetReplacements(replacementWireTypes);

        projectService.SetDetails(project, command.Details);

        projectRepository.Create(project);
        return project.Guid;
    }

    public void Handle(EditProject command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var project = projectRepository.Load(command.Guid, "Details,ReplacementWireTypes");

        if (projectRepository.Exists(x => x.Code.ToLower() == command.Code.ToLower() && x.Guid != command.Guid))
            throw new BusinessException("0", "کد پروژه تکراری است.");

        // if (_projectRepository.Exists(x => x.Name == command.Name && x.Guid != command.Guid))
        //     throw new BusinessException("0", "نام پروژه تکراری است.");

        var taskMasterGuid = taskMasterRepository.GetIdBy(command.TaskMasterGuid);
        var salonGuid = salonRepository.GetIdBy(command.SalonGuid);
        var projectTypeId = projectTypeRepository.GetIdBy(command.ProjectTypeGuid);
        var isActive = listItemRepository.GetIdBy(command.IsActive);

        project.Edit(actor, command.Code, command.Name, taskMasterGuid, projectTypeId, salonGuid,
            command.DeliveryDate, isActive, command.Description, projectService);

        List<ProjectReplacementWireType>? replacementWireTypes = null;

        if (command.ReplacementWireTypeGuids is not null)
            replacementWireTypes = command.ReplacementWireTypeGuids
                .Select(x => new ProjectReplacementWireType(actor, project.Id, wireTypeRepository.GetIdBy(x)))
                .ToList();

        project.SetReplacements(replacementWireTypes);

        projectService.SetDetails(project, command.Details);
    }

    public void Handle(RemoveProject command)
    {
        var project = projectRepository.Load(command.Guid);

        projectRepository.Delete(project);
    }
}