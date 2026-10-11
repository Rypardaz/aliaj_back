using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossier;

public class EditInquiryInformation : ICommand
{
    public Guid Guid { get; set; }
    public string No { get; set; }
    public string DocumentReceivedDate { get; set; }
    public string SubmissionDeadline { get; set; }
    public string GuaranteeReceivedDate { get; set; }
    public string InquirySentDate { get; set; }
    public long? QuotedAmount { get; set; }
    public Guid? InquiryResultGuid { get; set; }
    public Guid? LossReasonGuid { get; set; }
    public string Winner { get; set; }
    public long? WinningAmount { get; set; }
}
