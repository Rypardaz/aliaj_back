using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.ProjectDossierProduct;

public class ProjectDossierProductViewModel : ViewModelAbilities
{
    public int ItemNo { get; set; }
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string Unit { get; set; }
    public long Fee { get; set; }
    public decimal Qty { get; set; }
    public long Amount { get; set; }

    /*Prediction of sending to Hardface*/
    public int? BuyState { get; set; }
    public string BuyDate { get; set; }
    public string EstimatedShippingDate { get; set; }
    public int? LastState { get; set; }

}
