using AM.Application.Contracts.ProjectDossierCost;
using AM.Domain.ListItemAgg;
using AM.Domain.ProjectDossierCostAgg;
using AM.Domain.SalonAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;


public class ProjectDossierCostCommandHandler(
    IClaimHelper claimHelper,
    IProjectDossierCostRepository projectDossierCostRepository,
    IListItemRepository listItemRepository,
    ISalonRepository salonRepository)
    :
        ICommandHandler<CreateProjectDossierCost, Guid>,
        ICommandHandler<EditProjectDossierCost>,
        ICommandHandler<RemoveProjectDossierCost>
{
    public Guid Handle(CreateProjectDossierCost command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var projectDossierCost = new ProjectDossierCost(creator, command.ProjectDossierId, command.ItemType, command.ItemType, command.MaterialId, command.Thickness, command.Length, command.Width, command.Density, command.Size, command.Qty, command.Fee, command.Amount);
        projectDossierCostRepository.Create(projectDossierCost);

        return projectDossierCost.Guid;
    }

    public void Handle(EditProjectDossierCost command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossierCost = projectDossierCostRepository.Load(command.Guid);

        projectDossierCost.Edit(actor, command.ProjectDossierId, command.ItemType, command.ItemType, command.MaterialId, command.Thickness, command.Length, command.Width, command.Density, command.Size, command.Qty, command.Fee, command.Amount);
    }

    public void Handle(RemoveProjectDossierCost command)
    {
        var projectDossierCost = projectDossierCostRepository.Load(command.Guid);
        projectDossierCostRepository.Delete(projectDossierCost);
    }
}
