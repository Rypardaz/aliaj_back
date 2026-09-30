using AM.Domain.TenderInquiryAgg.Service;
using PhoenixFramework.Domain;

namespace AM.Domain.TenderInquiryAgg;

public class TenderInquiry : AuditableAggregateRootBase<long>
{
    public string ProjectCode { get; private set; }
    public int SaleDepartmentId { get; private set; }
    public long TaskMasterId { get; private set; }
    public int ApplicationTypeId { get; private set; }
    public long ProjectTypeId { get; private set; }
    public string Description { get; private set; }
    public string No { get; private set; }
    public string DocumentReceivedDate { get; private set; }
    public string SubmissionDeadline { get; private set; }
    public string GuaranteeReceivedDate { get; private set; }
    public string InquirySentDate { get; private set; }
    public long QuotedAmount { get; private set; }
    public int InquiryResultId { get; private set; }
    public int LossReasonId { get; private set; }
    public string Winner { get; private set; }
    public long WinningAmount { get; private set; }


    protected TenderInquiry()
    {
    }

    public TenderInquiry(Guid creator, string projectCode, int saleDepartmentId, long taskMasterId, int applicationTypeId, long projectTypeId, string description, string no, string documentReceivedDate, string submissionDeadline, string guaranteeReceivedDate, string inquirySentDate, long quotedAmount, int inquiryResultId, int lossReasonId, string winner, long winningAmount, ITenderInquiryService service) : base(creator)
    {
        service.ThrowWhenDuplicatedProjectCode(projectCode);
        service.ThrowWhenDuplicatedNo(no);

        ProjectCode = projectCode;
        SaleDepartmentId = saleDepartmentId;
        TaskMasterId = taskMasterId;
        ApplicationTypeId = applicationTypeId;
        ProjectTypeId = projectTypeId;
        Description = description;
        No = no;
        DocumentReceivedDate = documentReceivedDate;
        SubmissionDeadline = submissionDeadline;
        GuaranteeReceivedDate = guaranteeReceivedDate;
        InquirySentDate = inquirySentDate;
        QuotedAmount = quotedAmount;
        InquiryResultId = inquiryResultId;
        LossReasonId = lossReasonId;
        Winner = winner;
        WinningAmount = winningAmount;
    }

    public void Edit(Guid actor, string projectCode, int saleDepartmentId, long taskMasterId, int applicationTypeId, long projectTypeId, string description, string no, string documentReceivedDate, string submissionDeadline, string guaranteeReceivedDate, string inquirySentDate, long quotedAmount, int inquiryResultId, int lossReasonId, string winner, long winningAmount, ITenderInquiryService service)
    {
        service.ThrowWhenDuplicatedProjectCode(projectCode, Id);
        service.ThrowWhenDuplicatedNo(no, Id);

        ProjectCode = projectCode;
        SaleDepartmentId = saleDepartmentId;
        TaskMasterId = taskMasterId;
        ApplicationTypeId = applicationTypeId;
        ProjectTypeId = projectTypeId;
        Description = description;
        No = no;
        DocumentReceivedDate = documentReceivedDate;
        SubmissionDeadline = submissionDeadline;
        GuaranteeReceivedDate = guaranteeReceivedDate;
        InquirySentDate = inquirySentDate;
        QuotedAmount = quotedAmount;
        InquiryResultId = inquiryResultId;
        LossReasonId = lossReasonId;
        Winner = winner;
        WinningAmount = winningAmount;

        Modified(actor);
    }
}
