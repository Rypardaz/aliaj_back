using AM.Application.Contracts.ProjectDossier;
using AM.Domain.ListItemAgg;
using AM.Domain.ProjectDossierAgg;
using AM.Domain.ProjectDossierAgg.Service;
using AM.Domain.ProjectTypeAgg;
using AM.Domain.TaskMasterAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class ProjectDossierCommandHandler(
    IClaimHelper claimHelper,
    IProjectDossierRepository projectDossierRepository,
    IProjectDossierService projectDossierService,
    IListItemRepository listItemRepository,
    ITaskMasterRepository taskMasterRepository,
    IProjectTypeRepository projectTypeRepository) :
    ICommandHandler<CreateProjectDossier, Guid>,
    ICommandHandler<EditProjectDossier>,
    ICommandHandler<EditInquiryInformation>,
    ICommandHandler<EditContractInformation>,
    ICommandHandler<EditCost>,
    ICommandHandler<EditInvoice>,
    ICommandHandler<EditShippingEstimateHardface>,
    ICommandHandler<EditShippingEstimateRoller>,
    ICommandHandler<EditCostBeforImplementation>,
    ICommandHandler<EditActualCost>,
    ICommandHandler<RemoveProjectDossier>,
    ICommandHandler<ActivateProjectDossier>,
    ICommandHandler<DeactivateProjectDossier>
{
    public Guid Handle(CreateProjectDossier command)
    {
        var creator = claimHelper.GetCurrentUserGuid();

        var saleDepartmentId = listItemRepository.GetIdBy(command.SaleDepartmentGuid);
        var taskMasterId = taskMasterRepository.GetIdBy(command.TaskMasterGuid);
        var applicationTypeId = listItemRepository.GetIdBy(command.ApplicationTypeGuid);
        var projectTypeId = projectTypeRepository.GetIdBy(command.ProjectTypeGuid);

        var projectDossier = new ProjectDossier(creator, command.ProjectCode, saleDepartmentId, taskMasterId,
            applicationTypeId, projectTypeId, command.Description, projectDossierService);

        projectDossierRepository.Create(projectDossier);

        return projectDossier.Guid;
    }

    public void Handle(EditProjectDossier command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossier = projectDossierRepository.Load(command.Guid);

        var saleDepartmentId = listItemRepository.GetIdBy(command.SaleDepartmentGuid);
        var taskMasterId = taskMasterRepository.GetIdBy(command.TaskMasterGuid);
        var applicationTypeId = listItemRepository.GetIdBy(command.ApplicationTypeGuid);
        var projectTypeId = projectTypeRepository.GetIdBy(command.ProjectTypeGuid);

        projectDossier.Edit(actor, command.ProjectCode, saleDepartmentId, taskMasterId,
            applicationTypeId, projectTypeId, command.Description, projectDossierService);
    }

    public void Handle(EditInquiryInformation command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossier = projectDossierRepository.Load(command.Guid);

        int? inquiryResultId = null;
        inquiryResultId = listItemRepository.GetIdBy(command.InquiryResultGuid.Value);

        int? lossReasonId = null;
        lossReasonId = listItemRepository.GetIdBy(command.LossReasonGuid.Value);

        projectDossier.EditInquiryInformation(actor, command.No, command.DocumentReceivedDate,
            command.SubmissionDeadline, command.GuaranteeReceivedDate, command.InquirySentDate,
            command.QuotedAmount, inquiryResultId, lossReasonId, command.Winner, command.WinningAmount,
            projectDossierService);
    }

    public void Handle(EditContractInformation command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossier = projectDossierRepository.Load(command.Guid);

        projectDossier.EditContractInformation(actor, command.ContractDate, command.ContractAmount,
            command.DownPaymentPercentage,
            command.ContractDeliveryDate, command.EmployerNotificationDate);
    }

    public void Handle(EditCost command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossier = projectDossierRepository.Load(command.Guid);

        projectDossier.EditCost(actor, command.WeldingWireCost, command.SheetCost, command.PipeCost,
            command.OtherMaterialCost,
            command.ContractingCost, command.TotalProjectCost, command.CostToSalesRatio,
            command.WeldingWireCostToSalesRatio,
            command.SheetCostToSalesRatio, command.PipeCostToSalesRatio);
    }

    public void Handle(EditInvoice command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossier = projectDossierRepository.Load(command.Guid);

        projectDossier.EditInvoice(actor, command.InsuranceDeposit, command.PerformanceDeposit);
    }

    public void Handle(EditShippingEstimateHardface command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossier = projectDossierRepository.Load(command.Guid);

        projectDossier.EditShippingEstimateHardFace(actor, command.NotificationFactoryDate,
            command.EngineeringCompletionDate,
            command.BuyRequestDate, command.MaterialPurchaseState, command.ProjectCompletionForecast);
    }

    public void Handle(EditShippingEstimateRoller command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossier = projectDossierRepository.Load(command.Guid);

        projectDossier.EditShippingEstimateRoller(actor, command.TypeOfCargo, command.JoiningToFactoryDate,
            command.SendingDeadlineToTaskMaster,
            command.EstimatedShippingDateFromEshtehard, command.EstimatedDeliveryDateToClient,
            command.ActualShippingDateFromEshtehard, command.ActualDeliveryDateToClient);
    }

    public void Handle(EditCostBeforImplementation command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossier = projectDossierRepository.Load(command.Guid);

        projectDossier.EditCostBeforImplementation(actor, command.WeldingWireCostBeforImplementation,
            command.SheetCostBeforImplementation, command.PipeCostBeforImplementation,
            command.OtherMaterialCostBeforImplementation,
            command.ContractingCostBeforImplementation, command.TotalProjectCostBeforImplementation,
            command.CostToSalesRatioBeforImplementation, command.WeldingWireCostToSalesRatioBeforImplementation,
            command.SheetCostToSalesRatioBeforImplementation, command.PipeCostToSalesRatioBeforImplementation);
    }

    public void Handle(EditActualCost command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossier = projectDossierRepository.Load(command.Guid);

        projectDossier.EditActualCost(actor, command.WeldingWireActualCost, command.SheetActualCost,
            command.PipeActualCost, command.OtherMaterialActualCost,
            command.ContractingActualCost, command.TotalProjectActualCost, command.ActualCostToSalesRatio,
            command.ActualWeldingWireCostToSalesRatio,
            command.ActualSheetCostToSalesRatio, command.ActualPipeCostToSalesRatio);
    }


    public void Handle(RemoveProjectDossier command)
    {
        var projectDossier = projectDossierRepository.Load(command.Guid);
        projectDossierRepository.Delete(projectDossier);
    }

    public void Handle(ActivateProjectDossier command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossier = projectDossierRepository.Load(command.Guid);
        projectDossier.Activate();
    }

    public void Handle(DeactivateProjectDossier command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossier = projectDossierRepository.Load(command.Guid);
        projectDossier.Deactivate();
    }
}