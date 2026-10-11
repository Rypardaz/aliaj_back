using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossier;

public class EditInvoice : ICommand
{
    public Guid Guid { get; set; }
    public long? InsuranceDeposit { get; set; }
    public long? PerformanceDeposit { get; set; }
}
