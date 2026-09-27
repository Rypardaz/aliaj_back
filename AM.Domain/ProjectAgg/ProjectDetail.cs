using PhoenixFramework.Domain;

namespace AM.Domain.ProjectAgg;

public record ProjectDetail(
    long? PartId,
    string? PartCode,
    long? GasTypeId,
    long? WireTypeId,
    string? WireScrewId,
    decimal? ProductionQty,
    decimal? WireThickness,
    decimal? WireConsumption,
    long? PowderTypeId,
    string? Description)
    : ValueObjectBase
{
    public long Id { get; set; }
    public Guid Guid { get; set; } = Guid.NewGuid();
    public long ProjectId { get; set; }
    public long? PartId { get; set; } = PartId;
    public string? PartCode { get; private set; } = PartCode;
    public long? GasTypeId { get; set; } = GasTypeId;
    public long? WireTypeId { get; set; } = WireTypeId;
    public string? WireScrewId { get; set; } = WireScrewId;
    public decimal? ProductionQty { get; private set; } = ProductionQty;
    public decimal? WireThickness { get; set; } = WireThickness;
    public decimal? WireConsumption { get; set; } = WireConsumption;
    public long? PowderTypeId { get; set; } = PowderTypeId;
    public string? Description { get; private set; } = Description;
    public Project Project { get; set; }

    public void Edit(long? partId, string? partCode, long? gasTypeId, long? wireTypeId, string? wireScrewId,
        decimal? productionQty, decimal? wireThickness, decimal? wireConsumption, long? powderTypeId,
        string? description)
    {
        PartId = partId;
        PartCode = partCode;
        GasTypeId = gasTypeId;
        WireTypeId = wireTypeId;
        WireScrewId = wireScrewId;
        ProductionQty = productionQty;
        WireThickness = wireThickness;
        WireConsumption = wireConsumption;
        PowderTypeId = powderTypeId;
        Description = description;
    }
}