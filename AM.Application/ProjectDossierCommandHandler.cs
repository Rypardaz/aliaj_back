using AM.Application.Contracts.ProjectDossier;
using AM.Domain.ListItemAgg;
using AM.Domain.ProjectDossierAgg;
using AM.Domain.ProjectDossierAgg.Service;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class ProjectDossierCommandHandler(
    IClaimHelper claimHelper,
    IProjectDossierRepository tenderInquiryRepository,
    IProjectDossierService tenderInquiryService,
    IListItemRepository listItemRepository)
    :
        ICommandHandler<CreateProjectDossier, Guid>,
        ICommandHandler<EditProjectDossier>,
        ICommandHandler<RemoveProjectDossier>,
        ICommandHandler<ActivateProjectDossier>,
        ICommandHandler<DeactivateProjectDossier>
{
    public Guid Handle(CreateProjectDossier command)
    {
        var creator = claimHelper.GetCurrentUserGuid();

        int saleDepartmentId;
        saleDepartmentId = listItemRepository.GetIdBy(command.SaleDepartmentGuid);

        long taskMasterId;
        taskMasterId = listItemRepository.GetIdBy(command.TaskMasterGuid);

        int applicationTypeId;
        applicationTypeId = listItemRepository.GetIdBy(command.ApplicationTypeGuid);

        long projectTypeId;
        projectTypeId = listItemRepository.GetIdBy(command.ProjectTypeGuid);


        int? inquiryResultId = null;
        inquiryResultId = listItemRepository.GetIdBy(command.InquiryResultGuid.Value);

        int? lossReasonId = null;
        lossReasonId = listItemRepository.GetIdBy(command.LossReasonGuid.Value);

        var tenderInquiry = new ProjectDossier(creator, command.ProjectCode, saleDepartmentId, taskMasterId, 
            applicationTypeId, projectTypeId, command.Description, command.No, command.DocumentReceivedDate, 
            command.SubmissionDeadline, command.GuaranteeReceivedDate, command.InquirySentDate, 
            command.QuotedAmount, inquiryResultId, lossReasonId, command.Winner, command.WinningAmount, 
            tenderInquiryService);

        tenderInquiryRepository.Create(tenderInquiry);

        return tenderInquiry.Guid;
    }

    public void Handle(EditProjectDossier command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var tenderInquiry = tenderInquiryRepository.Load(command.Guid);

        int saleDepartmentId;
        saleDepartmentId = listItemRepository.GetIdBy(command.SaleDepartmentGuid);

        long taskMasterId;
        taskMasterId = listItemRepository.GetIdBy(command.TaskMasterGuid);

        int applicationTypeId;
        applicationTypeId = listItemRepository.GetIdBy(command.ApplicationTypeGuid);

        long projectTypeId;
        projectTypeId = listItemRepository.GetIdBy(command.ProjectTypeGuid);


        int? inquiryResultId = null;
        inquiryResultId = listItemRepository.GetIdBy(command.InquiryResultGuid.Value);

        int? lossReasonId = null;
        lossReasonId = listItemRepository.GetIdBy(command.LossReasonGuid.Value);

        tenderInquiry.Edit(actor, command.ProjectCode, saleDepartmentId, taskMasterId,
            applicationTypeId, projectTypeId, command.Description, command.No, command.DocumentReceivedDate,
            command.SubmissionDeadline, command.GuaranteeReceivedDate, command.InquirySentDate,
            command.QuotedAmount, inquiryResultId, lossReasonId, command.Winner, command.WinningAmount, 
            tenderInquiryService);
    }

    public void Handle(RemoveProjectDossier command)
    {
        var tenderInquiry = tenderInquiryRepository.Load(command.Guid);
        tenderInquiryRepository.Delete(tenderInquiry);
    }

    public void Handle(ActivateProjectDossier command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var tenderInquiry = tenderInquiryRepository.Load(command.Guid);
        tenderInquiry.Activate();
    }

    public void Handle(DeactivateProjectDossier command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var tenderInquiry = tenderInquiryRepository.Load(command.Guid);
        tenderInquiry.Deactivate();
    }
}