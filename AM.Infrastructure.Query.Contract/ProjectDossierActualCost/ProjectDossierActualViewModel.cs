using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.ProjectDossierActualCost;

public class ProjectDossierActualCostViewModel : ViewModelAbilities
{
    public int ItemType { get; set; }
    public int ItemNo { get; set; }
    public long MaterialId { get; set; }
    public string MaterialCode { get; set; }
    public string MaterialName { get; set; }
    public decimal? Thickness { get; set; }
    public decimal? Length { get; set; }
    public decimal? Width { get; set; }
    public decimal? Density { get; set; }
    public decimal? Size { get; set; }
    public decimal Qty { get; set; }
    public long Fee { get; set; }
    public long Amount { get; set; }
}
