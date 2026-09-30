using AM.Application.Contracts.TenderInquiry;
using AM.Domain.ListItemAgg;
using AM.Domain.SalonAgg;
using AM.Domain.TenderInquiryAgg;
using AM.Domain.TenderInquiryAgg.Service;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class TenderInquiryCommandHandler(
    IClaimHelper claimHelper,
    ITenderInquiryRepository tenderInquiryRepository,
    ITenderInquiryService tenderInquiryService,
    IListItemRepository listItemRepository,
    ISalonRepository salonRepository)
    :
        ICommandHandler<CreateTenderInquiry, Guid>,
        ICommandHandler<EditTenderInquiry>,
        ICommandHandler<RemoveTenderInquiry>,
        ICommandHandler<ActivateTenderInquiry>,
        ICommandHandler<DeactivateTenderInquiry>
{
    public Guid Handle(CreateTenderInquiry command)
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

        var tenderInquiry = new TenderInquiry(creator, command.ProjectCode, saleDepartmentId, taskMasterId, 
            applicationTypeId, projectTypeId, command.Description, command.No, command.DocumentReceivedDate, 
            command.SubmissionDeadline, command.GuaranteeReceivedDate, command.InquirySentDate, 
            command.QuotedAmount, inquiryResultId, lossReasonId, command.Winner, command.WinningAmount, 
            tenderInquiryService);

        tenderInquiryRepository.Create(tenderInquiry);

        return tenderInquiry.Guid;
    }

    public void Handle(EditTenderInquiry command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var tenderInquiry = tenderInquiryRepository.Load(command.Guid, "Salons");

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

    public void Handle(RemoveTenderInquiry command)
    {
        var tenderInquiry = tenderInquiryRepository.Load(command.Guid);
        tenderInquiryRepository.Delete(tenderInquiry);
    }

    public void Handle(ActivateTenderInquiry command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var tenderInquiry = tenderInquiryRepository.Load(command.Guid);
        tenderInquiry.Activate();
    }

    public void Handle(DeactivateTenderInquiry command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var tenderInquiry = tenderInquiryRepository.Load(command.Guid);
        tenderInquiry.Deactivate();
    }
}