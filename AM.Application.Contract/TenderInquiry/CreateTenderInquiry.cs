using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace AM.Application.Contracts.TenderInquiry;

public class CreateTenderInquiry : ICommand
{
    [Required]
    public string ProjectCode { get; set; }
    [Required]
    public Guid SaleDepartmentGuid { get; set; }
    [Required]
    public Guid TaskMasterGuid { get; set; }
    [Required]
    public Guid ApplicationTypeGuid { get; set; }
    [Required]
    public Guid ProjectTypeGuid { get; set; }
    public string Description { get; set; }
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
