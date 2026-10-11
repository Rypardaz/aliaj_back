using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossier;

public class EditProjectDossierCostBeforImplementation : ICommand
{
    public Guid Guid { get; set; }
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
}
