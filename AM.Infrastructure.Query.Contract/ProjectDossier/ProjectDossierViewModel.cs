using PhoenixFramework.Application.Query;
using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.TenderInquiry;

public class ProjectDossierViewModel : ViewModelAbilities
{
    public string ProjectCode { get; set; }
    public string SaleDepartmentName { get; set; }
    public string TaskMaster { get; set; }
    public string ApplicationTypeName { get; set; }
    public string ProjectTypeName { get; set; }
    public string Description { get; set; }

    /*Inquiry Information اطلاعات استعلام*/
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

    /*Contract Information اطلاعات قرارداد*/
    public string ContractDate { get; set; }
    public long? ContractAmount { get; set;}
    public int? DownPaymentPercentage { get; set;}
    public string ContractDeliveryDate { get; set;}
    public string EmployerNotificationDate { get; set;}

    /*ProjectDossier Cost محاسبه هزینه های پروژه*/
    public long? WeldingWireCost { get; set; }
    public long? SheetCost {get; set;}
    public long? PipeCost {get; set;}
    public long? OtherMaterialCost {get; set;}
    public long? ContractingCost {get; set;}
    public long? TotalProjectCost {get; set;}
    public decimal? CostToSalesRatio {get; set;}
    public decimal? WeldingWireCostToSalesRatio {get; set;}
    public decimal? SheetCostToSalesRatio {get; set;}
    public decimal? PipeCostToSalesRatio {get; set;}

    /*ProjectDossier invoice صورت وضعیت و کسورات پروژه*/
    public long? InsuranceDeposit { get; set; }
    public long? PerformanceDeposit { get; set; }

    /*Shipping estimate پیش بینی ارسال*/
    /*هاردفیس*/
    public string NotificationFactoryDate { get; set; }
    public string EngineeringCompletionDate { get; set; }
    public string BuyRequestDate { get; set; }
    public int? MaterialPurchaseState { get; set; }
    public string ProjectCompletionForecast { get; set; }
    /*غلطک*/
    public int? TypeOfCargo { get; set; }
    public string JoiningToFactoryDate { get; set; }
    public string SendingDeadlineToTaskMaster { get; set; }
    public string EstimatedShippingDateFromEshtehard { get; set; }
    public string EstimatedDeliveryDateToClient { get; set; }
    public string ActualShippingDateFromEshtehard { get; set; }
    public string ActualDeliveryDateToClient { get; set; }

    /*ProjectDossier Cost befor implementation محاسبه هزینه قبل از اجرا*/
    public long? WeldingWireCostBeforImplementation { get; set; }
    public long? SheetCostBeforImplementation { get; set; }
    public long? PipeCostBeforImplementation { get; set; }
    public long? OtherMaterialCostBeforImplementation { get; set; }
    public long? ContractingCostBeforImplementation { get; set; }
    public long? TotalProjectCostBeforImplementation { get; set; }
    public decimal? CostToSalesRatioBeforImplementation { get; set; }
    public decimal? WeldingWireCostToSalesRatioBeforImplementation { get; set; }
    public decimal? SheetCostToSalesRatioBeforImplementation { get; set; }
    public decimal? PipeCostToSalesRatioBeforImplementation { get; set; }


    /*ProjectDossier Actual Cost محاسبه هزینه های واقعی*/
    public long? WeldingWireActualCost { get; set; }
    public long? SheetActualCost { get; set; }
    public long? PipeActualCost { get; set; }
    public long? OtherMaterialActualCost { get; set; }
    public long? ContractingActualCost { get; set; }
    public long? TotalProjectActualCost { get; set; }
    public decimal? ActualCostToSalesRatio { get; set; }
    public decimal? ActualWeldingWireCostToSalesRatio { get; set; }
    public decimal? ActualSheetCostToSalesRatio { get; set; }
    public decimal? ActualPipeCostToSalesRatio { get; set; }
}
