using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossierInvoice;

public class CreateProjectDossierInvoice : ICommand
{
    public long ProjectDossierId { get; set; }
    public long ProjectDossierProductId { get; set; }
    public string Date { get; set; }
    public string No { get; set; }
    public decimal Qty { get; set; }
    public long? Amount { get; set; }
}
