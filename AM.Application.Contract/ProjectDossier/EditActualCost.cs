using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossier;

public class EditActualCost : ICommand
{
    public Guid Guid { get; set; }
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