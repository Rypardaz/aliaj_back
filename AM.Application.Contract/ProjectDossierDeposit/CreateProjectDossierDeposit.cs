using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossierDeposit;

public class CreateProjectDossierDeposit : ICommand
{
    public long ProjectDossierId { get; set; }
    public string Date { get; set; }
    public long Deposit { get; set; }
}
