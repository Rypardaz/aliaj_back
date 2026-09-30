using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace AM.Application.Contracts.TenderInquiry;

public class CreateTenderInquiry : ICommand
{
    [Required]
    public string ProjectCode { get; set; }
    [Required]
    public int SaleDepartmentId { get; set; }
    [Required]
    public long TaskMasterId { get; set; }
    [Required]
    public int ApplicationTypeId { get; set; }
    [Required]
    public long ProjectTypeId { get; set; }
    public string Description { get; set; }
    public string No { get; set; }
    public string DocumentReceivedDate { get; set; }
    public string SubmissionDeadline { get; set; }
    public string GuaranteeReceivedDate { get; set; }
    public string InquirySentDate { get; set; }
    public long QuotedAmount { get; set; }
    public int InquiryResultId { get; set; }
    public int LossReasonId { get; set; }
    public string Winner { get; set; }
    public long WinningAmount { get; set; }
}
