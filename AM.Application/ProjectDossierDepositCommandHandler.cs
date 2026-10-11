using AM.Application.Contracts.ProjectDossierDeposit;
using AM.Domain.ListItemAgg;
using AM.Domain.ProjectDossierDepositAgg;
using AM.Domain.SalonAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class ProjectDossierDepositCommandHandler(
    IClaimHelper claimHelper,
    IProjectDossierDepositRepository projectDossierDepositRepository,
    IListItemRepository listItemRepository,
    ISalonRepository salonRepository)
    :
        ICommandHandler<CreateProjectDossierDeposit, Guid>,
        ICommandHandler<EditProjectDossierDeposit>,
        ICommandHandler<RemoveProjectDossierDeposit>
{
    public Guid Handle(CreateProjectDossierDeposit command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var projectDossierDeposit = new ProjectDossierDeposit(creator, command.ProjectDossierId, command.Date, command.Deposit);
        projectDossierDepositRepository.Create(projectDossierDeposit);

        return projectDossierDeposit.Guid;
    }

    public void Handle(EditProjectDossierDeposit command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossierDeposit = projectDossierDepositRepository.Load(command.Guid);

        projectDossierDeposit.Edit(actor, command.ProjectDossierId, command.Date, command.Deposit);
    }

    public void Handle(RemoveProjectDossierDeposit command)
    {
        var projectDossierDeposit = projectDossierDepositRepository.Load(command.Guid);
        projectDossierDepositRepository.Delete(projectDossierDeposit);
    }
}