using PhoenixFramework.Domain;
using AM.Domain.ProjectDossierAgg.Service;

namespace AM.Domain.ProjectDossierAgg;

public class ProjectDossier : AuditableAggregateRootBase<long>
{
    public string ProjectCode { get; private set; }
    public int SaleDepartmentId { get; private set; }
    public long TaskMasterId { get; private set; }
    public int ApplicationTypeId { get; private set; }
    public long ProjectTypeId { get; private set; }
    public string Description { get; private set; }

    /*Inquiry information*/
    public string? No { get; private set; }
    public string? DocumentReceivedDate { get; private set; }
    public string? SubmissionDeadline { get; private set; }
    public string? GuaranteeReceivedDate { get; private set; }
    public string? InquirySentDate { get; private set; }
    public long? QuotedAmount { get; private set; }
    public int? InquiryResultId { get; private set; }
    public int? LossReasonId { get; private set; }
    public string? Winner { get; private set; }
    public long? WinningAmount { get; private set; }

    /*Contract information*/
    public string? ContractDate { get; private set; }
    public long? ContractAmount { get; private set; }
    public int? DownPaymentPercentage { get; private set; }
    public string? ContractDeliveryDate { get; private set; }
    public string? EmployerNotificationDate { get; private set; }

    /*Cost*/
    public long? WeldingWireCost { get; private set; }
    public long? SheetCost {get; private set; }
    public long? PipeCost {get; private set; }
    public long? OtherMaterialCost {get; private set; }
    public long? ContractingCost {get; private set; }
    public long? TotalProjectCost {get; private set; }
    public decimal? CostToSalesRatio {get; private set; }
    public decimal? WeldingWireCostToSalesRatio {get; private set; }
    public decimal? SheetCostToSalesRatio {get; private set; }
    public decimal? PipeCostToSalesRatio {get; private set; }

    /*invoice*/
    public long? InsuranceDeposit {get; private set; }
    public long? PerformanceDeposit { get; private set; }

    /*Shipping estimate hardface*/
    public string? NotificationFactoryDate { get; private set; }
    public string? EngineeringCompletionDate { get; private set; }
    public string? BuyRequestDate { get; private set; }
    public int? MaterialPurchaseState { get; private set; }
    public string? ProjectCompletionForecast { get; private set; }

    /*Shipping estimate roller*/
    public int? TypeOfCargo { get; private set; }
    public string? JoiningToFactoryDate {get; private set; }
    public string? SendingDeadlineToTaskMaster {get; private set; }
    public string? EstimatedShippingDateFromEshtehard {get; private set; }
    public string? EstimatedDeliveryDateToClient {get; private set; }
    public string? ActualShippingDateFromEshtehard {get; private set; }
    public string? ActualDeliveryDateToClient {get; private set; }

    /*Cost befor implementation*/
    public long? WeldingWireCostBeforImplementation { get; private set; }
    public long? SheetCostBeforImplementation { get; private set; }
    public long? PipeCostBeforImplementation { get; private set; }
    public long? OtherMaterialCostBeforImplementation { get; private set; }
    public long? ContractingCostBeforImplementation { get; private set; }
    public long? TotalProjectCostBeforImplementation { get; private set; }
    public decimal? CostToSalesRatioBeforImplementation { get; private set; }
    public decimal? WeldingWireCostToSalesRatioBeforImplementation { get; private set; }
    public decimal? SheetCostToSalesRatioBeforImplementation { get; private set; }
    public decimal? PipeCostToSalesRatioBeforImplementation { get; private set; }

    /*Actual Cost*/
    public long? WeldingWireActualCost { get; private set; }
    public long? SheetActualCost { get; private set; }
    public long? PipeActualCost { get; private set; }
    public long? OtherMaterialActualCost { get; private set; }
    public long? ContractingActualCost { get; private set; }
    public long? TotalProjectActualCost { get; private set; }
    public decimal? ActualCostToSalesRatio { get; private set; }
    public decimal? ActualWeldingWireCostToSalesRatio { get; private set; }
    public decimal? ActualSheetCostToSalesRatio { get; private set; }
    public decimal? ActualPipeCostToSalesRatio { get; private set; }


    protected ProjectDossier()
    {
    }

    public ProjectDossier(Guid creator, string projectCode, int saleDepartmentId, long taskMasterId, int applicationTypeId, 
        long projectTypeId, string description, IProjectDossierService service) : base(creator)
    {
        service.ThrowWhenDuplicatedProjectCode(projectCode);

        ProjectCode = projectCode;
        SaleDepartmentId = saleDepartmentId;
        TaskMasterId = taskMasterId;
        ApplicationTypeId = applicationTypeId;
        ProjectTypeId = projectTypeId;
        Description = description;
    }

    public void Edit(Guid actor, string projectCode, int saleDepartmentId, long taskMasterId, int applicationTypeId, 
        long projectTypeId, string description, IProjectDossierService service)
    {
        service.ThrowWhenDuplicatedProjectCode(projectCode, Id);

        ProjectCode = projectCode;
        SaleDepartmentId = saleDepartmentId;
        TaskMasterId = taskMasterId;
        ApplicationTypeId = applicationTypeId;
        ProjectTypeId = projectTypeId;
        Description = description;

        Modified(actor);
    }

    public void EditInquiryInformation(Guid actor, string no, string documentReceivedDate, string submissionDeadline,
        string guaranteeReceivedDate, string inquirySentDate, long? quotedAmount, int? inquiryResultId,
        int? lossReasonId, string winner, long? winningAmount, IProjectDossierService service)
    {
        service.ThrowWhenDuplicatedNo(no, Id);

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

    public void EditContractInformation(Guid actor, string contractDate, long? contractAmount, int? downPaymentPercentage, 
        string contractDeliveryDate, string employerNotificationDate)
    {
        ContractDate = contractDate;
        ContractAmount = contractAmount;
        DownPaymentPercentage = downPaymentPercentage;
        ContractDeliveryDate = contractDeliveryDate;
        EmployerNotificationDate = employerNotificationDate;


        Modified(actor);
    }

    public void EditCost(Guid actor, long? weldingWireCost, long? sheetCost, long? pipeCost, long? otherMaterialCost,
        long? contractingCost, long? totalProjectCost, decimal? costToSalesRatio, decimal? weldingWireCostToSalesRatio, 
        decimal? sheetCostToSalesRatio, decimal? pipeCostToSalesRatio)
    {
        WeldingWireCost = weldingWireCost;
        SheetCost = sheetCost;
        PipeCost = pipeCost;
        OtherMaterialCost = otherMaterialCost;
        ContractingCost = contractingCost;
        TotalProjectCost = totalProjectCost;
        CostToSalesRatio = costToSalesRatio;
        WeldingWireCostToSalesRatio = weldingWireCostToSalesRatio;
        SheetCostToSalesRatio = sheetCostToSalesRatio;
        PipeCostToSalesRatio = pipeCostToSalesRatio;

        Modified(actor);
    }

    public void EditInvoice(Guid actor, long? insuranceDeposit, long? performanceDeposit)
    {
        InsuranceDeposit = insuranceDeposit;
        PerformanceDeposit = performanceDeposit;

        Modified(actor);
    }

    public void EditShippingEstimateHardFace(Guid actor, string notificationFactoryDate, string engineeringCompletionDate,
        string buyRequestDate, int? materialPurchaseState, string projectCompletionForecast)
    {
        NotificationFactoryDate = notificationFactoryDate;
        EngineeringCompletionDate = engineeringCompletionDate;
        BuyRequestDate = buyRequestDate;
        MaterialPurchaseState = materialPurchaseState;
        ProjectCompletionForecast = projectCompletionForecast;

        Modified(actor);
    }

    public void EditShippingEstimateRoller(Guid actor, int? typeOfCargo, string joiningToFactoryDate, string sendingDeadlineToTaskMaster,
        string estimatedShippingDateFromEshtehard, string estimatedDeliveryDateToClient, string actualShippingDateFromEshtehard, 
        string actualDeliveryDateToClient)
    {
        TypeOfCargo = typeOfCargo;
        JoiningToFactoryDate = joiningToFactoryDate;
        SendingDeadlineToTaskMaster = sendingDeadlineToTaskMaster;
        EstimatedShippingDateFromEshtehard = estimatedShippingDateFromEshtehard;
        EstimatedDeliveryDateToClient = estimatedDeliveryDateToClient;
        ActualShippingDateFromEshtehard = actualShippingDateFromEshtehard;
        ActualDeliveryDateToClient = actualDeliveryDateToClient;

        Modified(actor);
    }

    public void EditCostBeforImplementation(Guid actor, long? weldingWireCostBeforImplementation, long? sheetCostBeforImplementation, 
        long? pipeCostBeforImplementation, long? otherMaterialCostBeforImplementation, long? contractingCostBeforImplementation, 
        long? totalProjectCostBeforImplementation, decimal? costToSalesRatioBeforImplementation, decimal? weldingWireCostToSalesRatioBeforImplementation,
        decimal? sheetCostToSalesRatioBeforImplementation, decimal? pipeCostToSalesRatioBeforImplementation)
    {
        WeldingWireCostBeforImplementation = weldingWireCostBeforImplementation;
        SheetCostBeforImplementation = sheetCostBeforImplementation;
        PipeCostBeforImplementation = pipeCostBeforImplementation;
        OtherMaterialCostBeforImplementation = otherMaterialCostBeforImplementation;
        ContractingCostBeforImplementation = contractingCostBeforImplementation;
        TotalProjectCostBeforImplementation = totalProjectCostBeforImplementation;
        CostToSalesRatioBeforImplementation = costToSalesRatioBeforImplementation;
        WeldingWireCostToSalesRatioBeforImplementation = weldingWireCostToSalesRatioBeforImplementation;
        SheetCostToSalesRatioBeforImplementation = sheetCostToSalesRatioBeforImplementation;
        PipeCostToSalesRatioBeforImplementation = pipeCostToSalesRatioBeforImplementation;

        Modified(actor);
    }

    public void EditActualCost(Guid actor, long? weldingWireActualCost, long? sheetActualCost,
        long? pipeActualCost, long? otherMaterialActualCost, long? contractingActualCost,
        long? totalProjectActualCost, decimal? actualCostToSalesRatio, decimal? actualWeldingWireCostToSalesRatio,
        decimal? actualSheetCostToSalesRatio, decimal? actualPipeCostToSalesRatio)
    {
        WeldingWireActualCost = weldingWireActualCost;
        SheetActualCost = sheetActualCost;
        PipeActualCost = pipeActualCost;
        OtherMaterialActualCost = otherMaterialActualCost;
        ContractingActualCost = contractingActualCost;
        TotalProjectActualCost = totalProjectActualCost;
        ActualCostToSalesRatio = actualCostToSalesRatio;
        ActualWeldingWireCostToSalesRatio = actualWeldingWireCostToSalesRatio;
        ActualSheetCostToSalesRatio = actualSheetCostToSalesRatio;
        ActualPipeCostToSalesRatio = actualPipeCostToSalesRatio;

        Modified(actor);
    }

}
