using PhoenixFramework.Domain;

namespace AM.Domain.ProjectDossierProductAgg;

public class ProjectDossierProduct : AuditableAggregateRootBase<long>
{
    public long ProjectDossierId { get; private set; }
    public int ItemNo { get; private set; }
    public string ProductCode { get; private set; }
    public string ProductName { get; private set; }
    public string Unit { get; private set; }
    public long Fee { get; private set; }
    public decimal Qty { get; private set; }
    public long Amount { get; private set; }

    /*Prediction of sending to Hardface*/
    public int? BuyState { get; private set; }
    public string BuyDate { get; private set; }
    public string EstimatedShippingDate { get; private set; }
    public int? LastState { get; private set; }

    protected ProjectDossierProduct() { }

    public ProjectDossierProduct(Guid creator, long projectDossierId, int itemNo, string productCode, string productName,
        string unit, long fee, decimal qty, long amount, int? buyState, string buyDate, string estimatedShippingDate,
        int? lastState) : base(creator)
    {
        SetProperties(projectDossierId, itemNo, productCode, productName, unit, fee, qty, amount, buyState, buyDate, estimatedShippingDate, lastState);
    }

    public void Edit(Guid actor, long projectDossierId, int itemNo, string productCode, string productName,
        string unit, long fee, decimal qty, long amount, int? buyState, string buyDate, string estimatedShippingDate,
        int? lastState)
    {
        SetProperties(projectDossierId, itemNo, productCode, productName, unit, fee, qty, amount, buyState, buyDate, estimatedShippingDate, lastState);
        Modified(actor);
    }

    private void SetProperties(long projectDossierId, int itemNo, string productCode, string productName, string unit, long fee, decimal qty, long amount, int? buyState, string buyDate, string estimatedShippingDate, int? lastState)
    {
        ProjectDossierId = projectDossierId;
        ItemNo = itemNo;
        ProductCode = productCode;
        ProductName = productName;
        Unit = unit;
        Fee = fee;
        Qty = qty;
        Amount = amount;
        BuyState = buyState;
        BuyDate = buyDate;
        EstimatedShippingDate = estimatedShippingDate;
        LastState = lastState;
    }
}
