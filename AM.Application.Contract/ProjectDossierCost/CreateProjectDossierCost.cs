using AM.Application.Contracts.ProjectDossierActualCost;
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossierCost;

public class CreateProjectDossierCost : ICommand
{
    public long ProjectDossierId { get; set; }
    public int ItemType { get; set; }
    public int ItemNo { get; set; }
    public int MaterialId { get; set; }
    public decimal? Thickness { get; set; }
    public decimal? Length { get; set; }
    public decimal? Width { get; set; }
    public decimal? Density { get; set; }
    public decimal? Size { get; set; }
    public decimal Qty { get; set; }
    public long Fee { get; set; }
    public long Amount { get; set; }
}
