using AM.Application.Contracts.ProjectDossierInvoice;
using AM.Domain.ListItemAgg;
using AM.Domain.ProjectDossierInvoiceAgg;
using AM.Domain.SalonAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class ProjectDossierInvoiceCommandHandler(
    IClaimHelper claimHelper,
    IProjectDossierInvoiceRepository projectDossierInvoiceRepository,
    IListItemRepository listItemRepository,
    ISalonRepository salonRepository)
    :
        ICommandHandler<CreateProjectDossierInvoice, Guid>,
        ICommandHandler<EditProjectDossierInvoice>,
        ICommandHandler<RemoveProjectDossierInvoice>
{
    public Guid Handle(CreateProjectDossierInvoice command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var projectDossierInvoice = new ProjectDossierInvoice(creator, command.ProjectDossierId, command.ProjectDossierProductId, command.Date, command.No, command.Qty, command.Amount);
        projectDossierInvoiceRepository.Create(projectDossierInvoice);

        return projectDossierInvoice.Guid;
    }

    public void Handle(EditProjectDossierInvoice command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossierInvoice = projectDossierInvoiceRepository.Load(command.Guid);

        projectDossierInvoice.Edit(actor, command.ProjectDossierId, command.ProjectDossierProductId, command.Date, command.No, command.Qty, command.Amount);
    }

    public void Handle(RemoveProjectDossierInvoice command)
    {
        var projectDossierInvoice = projectDossierInvoiceRepository.Load(command.Guid);
        projectDossierInvoiceRepository.Delete(projectDossierInvoice);
    }
}