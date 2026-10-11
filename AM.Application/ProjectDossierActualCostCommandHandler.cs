using AM.Application.Contracts.ProjectDossierActualCost;
using AM.Domain.ListItemAgg;
using AM.Domain.ProjectDossierActualCostAdd;
using AM.Domain.SalonAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class ProjectDossierActualCostCommandHandler(
    IClaimHelper claimHelper,
    IProjectDossierActualCostRepository projectDossierActualCostRepository,
    IListItemRepository listItemRepository,
    ISalonRepository salonRepository)
    :
        ICommandHandler<CreateProjectDossierActualCost, Guid>,
        ICommandHandler<EditProjectDossierActualCost>,
        ICommandHandler<RemoveProjectDossierActualCost>
{
    public Guid Handle(CreateProjectDossierActualCost command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var projectDossierActualCost = new ProjectDossierActualCost(creator, command.ProjectDossierId, command.ItemType, command.ItemType, command.MaterialId, command.Thickness, command.Length, command.Width, command.Density, command.Size, command.Qty, command.Fee, command.Amount);
        projectDossierActualCostRepository.Create(projectDossierActualCost);

        return projectDossierActualCost.Guid;
    }

    public void Handle(EditProjectDossierActualCost command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossierActualCost = projectDossierActualCostRepository.Load(command.Guid);

        projectDossierActualCost.Edit(actor, command.ProjectDossierId, command.ItemType, command.ItemType, command.MaterialId, command.Thickness, command.Length, command.Width, command.Density, command.Size, command.Qty, command.Fee, command.Amount);
    }

    public void Handle(RemoveProjectDossierActualCost command)
    {
        var projectDossierActualCost = projectDossierActualCostRepository.Load(command.Guid);
        projectDossierActualCostRepository.Delete(projectDossierActualCost);
    }
}
