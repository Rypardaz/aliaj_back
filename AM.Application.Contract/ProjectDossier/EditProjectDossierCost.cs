using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossier;

public class EditProjectDossierCost : ICommand
{
    public Guid Guid { get; set; }
    public long? WeldingWireCost { get; set; }
    public long? SheetCost { get; set; }
    public long? PipeCost { get; set; }
    public long? OtherMaterialCost { get; set; }
    public long? ContractingCost { get; set; }
    public long? TotalProjectCost { get; set; }
    public decimal? CostToSalesRatio { get; set; }
    public decimal? WeldingWireCostToSalesRatio { get; set; }
    public decimal? SheetCostToSalesRatio { get; set; }
    public decimal? PipeCostToSalesRatio { get; set; }
}
