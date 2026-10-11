using AM.Application.Contracts.ProjectDossierCostBeforImplementation;
using AM.Domain.ListItemAgg;
using AM.Domain.ProjectDossierCostBeforImplementationAgg;
using AM.Domain.SalonAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class ProjectDossierCostBeforImplementationCommandHandler(
    IClaimHelper claimHelper,
    IProjectDossierCostBeforImplementationRepository projectDossierCostBeforImplementationRepository,
    IListItemRepository listItemRepository,
    ISalonRepository salonRepository)
    :
        ICommandHandler<CreateProjectDossierCostBeforImplementation, Guid>,
        ICommandHandler<EditProjectDossierCostBeforImplementation>,
        ICommandHandler<RemoveProjectDossierCostBeforImplementation>
{
    public Guid Handle(CreateProjectDossierCostBeforImplementation command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var projectDossierCostBeforImplementation = new ProjectDossierCostBeforImplementation(creator, command.ProjectDossierId, command.ItemType, command.ItemType, command.MaterialId, command.Thickness, command.Length, command.Width, command.Density, command.Size, command.Qty, command.Fee, command.Amount);
        projectDossierCostBeforImplementationRepository.Create(projectDossierCostBeforImplementation);

        return projectDossierCostBeforImplementation.Guid;
    }

    public void Handle(EditProjectDossierCostBeforImplementation command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossierCostBeforImplementation = projectDossierCostBeforImplementationRepository.Load(command.Guid);

        projectDossierCostBeforImplementation.Edit(actor, command.ProjectDossierId, command.ItemType, command.ItemType, command.MaterialId, command.Thickness, command.Length, command.Width, command.Density, command.Size, command.Qty, command.Fee, command.Amount);
    }

    public void Handle(RemoveProjectDossierCostBeforImplementation command)
    {
        var projectDossierCostBeforImplementation = projectDossierCostBeforImplementationRepository.Load(command.Guid);
        projectDossierCostBeforImplementationRepository.Delete(projectDossierCostBeforImplementation);
    }
}