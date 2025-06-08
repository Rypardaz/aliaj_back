using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.Project;

public class ProjectDetailComboModel : ComboBase
{
    public Guid ProjectGuid { get; set; }
    public Guid? GasTypeGuid { get; set; }
    public Guid? PowderTypeGuid { get; set; }
    public Guid? WireTypeGuid { get; set; }
    public string? WireTypeName { get; set; }
    public Guid? WireScrewGuid { get; set; }
    public decimal? WireConsumption { get; set; }
    public List<ProjectReplacementWireTypeViewModel>? ReplacementWireTypes { get; set; }
}