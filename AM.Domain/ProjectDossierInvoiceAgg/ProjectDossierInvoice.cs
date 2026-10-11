using PhoenixFramework.Domain;

namespace AM.Domain.ProjectDossierInvoiceAgg;

public class ProjectDossierInvoice : AuditableAggregateRootBase<long>
{
    public long ProjectDossierId { get; private set; }
    public long ProjectDossierProductId { get; private set; }
    public string Date { get; private set; }
    public string No { get; private set; }
    public decimal Qty { get; private set; }
    public long? Amount { get; private set; }

    protected ProjectDossierInvoice() { }

    public ProjectDossierInvoice(Guid creator, long projectDossierId, long projectDossierProductId, string date,
        string no, decimal qty, long? amount) : base(creator)
    {
        SetProperties(projectDossierId, projectDossierProductId, date, no, qty, amount);
    }

    public void Edit(Guid actor, long projectDossierId, long projectDossierProductId, string date,
        string no, decimal qty, long? amount)
    {
        SetProperties(projectDossierId, projectDossierProductId, date, no, qty, amount);
        Modified(actor);
    }

    private void SetProperties(long projectDossierId, long projectDossierProductId, string date, string no, decimal qty, long? amount)
    {
        ProjectDossierId = projectDossierId;
        ProjectDossierProductId = projectDossierProductId;
        Date = date;
        No = no;
        Qty = qty;
        Amount = amount;
    }
}
