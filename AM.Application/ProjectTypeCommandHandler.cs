using Ex.Application.Contracts.ProjectType;
using Ex.Domain.ProjectTypeAgg.Service;
using Ex.Domain.ProjectTypeAgg;
using Ex.Domain.SalonAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace Ex.Application;

public class ProjectTypeCommandHandler(
    IClaimHelper claimHelper,
    IProjectTypeRepository projectTypeRepository,
    IProjectTypeService projectTypeService,
    ISalonRepository salonRepository)
    :
        ICommandHandlerAsync<CreateProjectType, Guid>,
        ICommandHandlerAsync<EditProjectType>,
        ICommandHandler<RemoveProjectType>,
        ICommandHandler<ActivateProjectType>,
        ICommandHandler<DeactivateProjectType>
{
    public async Task<Guid> Handle(CreateProjectType command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var salonId = await salonRepository.GetIdByAsync(command.SalonGuid);
        var projectType = new ProjectType(creator, command.Name, salonId, projectTypeService);
        await projectTypeRepository.CreateAsync(projectType);

        return projectType.Guid;
    }

    public async Task Handle(EditProjectType command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectType = projectTypeRepository.Load(command.Guid);
        var salonId = await salonRepository.GetIdByAsync(command.SalonGuid);
        projectType.Edit(actor, command.Name, salonId, projectTypeService);
    }

    public void Handle(RemoveProjectType command)
    {
        var projectType = projectTypeRepository.Load(command.Guid);
        projectTypeRepository.Delete(projectType);
    }
    public void Handle(ActivateProjectType command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectType = projectTypeRepository.Load(command.Guid);
        projectType.Activate();
    }

    public void Handle(DeactivateProjectType command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectType = projectTypeRepository.Load(command.Guid);
        projectType.Deactivate();
    }
}