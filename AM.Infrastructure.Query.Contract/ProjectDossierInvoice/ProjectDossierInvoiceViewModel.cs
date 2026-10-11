using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.ProjectDossierInvoice;

public class ProjectDossierInvoiceViewModel : ViewModelAbilities
{
    public long ProjectDossierProductId { get; set; }
    public string ProjectDossierProductCode { get; set; }
    public string ProjectDossierProductName { get; set; }
    public string ProjectDossierUnit { get; set; }
    public string Date { get; set; }
    public string No { get; set; }
    public decimal Qty { get; set; }
    public long? Amount { get; set; }
}
