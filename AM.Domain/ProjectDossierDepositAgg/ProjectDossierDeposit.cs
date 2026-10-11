using PhoenixFramework.Domain;

namespace AM.Domain.ProjectDossierDepositAgg;

public class ProjectDossierDeposit : AuditableAggregateRootBase<long>
{
    public long ProjectDossierId { get; private set; }
    public string Date { get; private set; }
    public long Deposit { get; private set; }

    protected ProjectDossierDeposit() { }

    public ProjectDossierDeposit(Guid creator, long projectDossierId, string date, long deposit) : base(creator)
    {
        SetProperties(projectDossierId, date, deposit);
    }

    public void Edit(Guid actor, long projectDossierId, string date, long deposit)
    {
        SetProperties(projectDossierId, date, deposit);
        Modified(actor);
    }

    private void SetProperties(long projectDossierId, string date, long deposit)
    {
        ProjectDossierId = projectDossierId;
        Date = date;
        Deposit = deposit;
    }
}
