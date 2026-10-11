using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.ProjectDossierDeposit;

public class ProjectDossierDepositViewModel : ViewModelAbilities
{
    public string Date { get; set; }
    public long Deposit { get; set; }
}
