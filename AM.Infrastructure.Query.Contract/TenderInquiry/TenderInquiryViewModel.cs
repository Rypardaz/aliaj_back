using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.TenderInquiry;

public class TenderInquiryViewModel : ViewModelAbilities
{
    public string ProjectCode { get; set; }
    public string SaleDepartmentName { get; set; }
    public string TaskMaster { get; set; }
    public string ApplicationTypeName { get; set; }
    public string ProjectTypeName { get; set; }
    public string Description { get; set; }
    public string No { get; set; }
	public string DocumentReceivedDate { get; set; }
    public string SubmissionDeadline { get; set; }
    public string GuaranteeReceivedDate { get; set; }
    public string InquirySentDate { get; set; }
    public long QuotedAmount { get; set; }
    public string InquiryResultName { get; set; }
    public string LossReasonName { get; set; }
    public string Winner { get; set; }
    public long WinningAmount { get; set; }
}
