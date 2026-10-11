using PhoenixFramework.Domain;

namespace AM.Domain.ProjectDossierCostBeforImplementationAgg;

public class ProjectDossierCostBeforImplementation : AuditableAggregateRootBase<long>
{
    public long ProjectDossierId { get; private set; }
    public int ItemType { get; private set; }
    public int ItemNo { get; private set; }
    public int MaterialId { get; private set; }
    public decimal? Thickness { get; private set; }
    public decimal? Length { get; private set; }
    public decimal? width { get; private set; }
    public decimal? Density { get; private set; }
    public decimal? Size { get; private set; }
    public decimal Qty { get; private set; }
    public long Fee { get; private set; }
    public long Amount { get; private set; }

    protected ProjectDossierCostBeforImplementation() { }

    public ProjectDossierCostBeforImplementation(Guid creator, long projectDossierId, int itemType, int itemNo,
        int materialId, decimal? thickness, decimal? length, decimal? width, decimal? density, decimal? size,
        decimal qty, long fee, long amount) : base(creator)
    {
        SetProperties(projectDossierId, itemType, itemNo, materialId, thickness, length, width, density, size, qty, fee, amount);
    }

    public void Edit(Guid actor, long projectDossierId, int itemType, int itemNo,
       int materialId, decimal? thickness, decimal? length, decimal? width, decimal? density, decimal? size,
       decimal qty, long fee, long amount)
    {
        SetProperties(projectDossierId, itemType, itemNo, materialId, thickness, length, width, density, size, qty, fee, amount);
        Modified(actor);
    }

    private void SetProperties(long projectDossierId, int itemType, int itemNo, int materialId, decimal? thickness, decimal? length, decimal? width, decimal? density, decimal? size, decimal qty, long fee, long amount)
    {
        ProjectDossierId = projectDossierId;
        ItemType = itemType;
        ItemNo = itemNo;
        MaterialId = materialId;
        Thickness = thickness;
        Length = length;
        this.width = width;
        Density = density;
        Size = size;
        Qty = qty;
        Fee = fee;
        Amount = amount;
    }
}
