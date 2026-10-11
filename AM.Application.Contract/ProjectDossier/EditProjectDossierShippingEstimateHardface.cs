using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossier;

public class EditProjectDossierShippingEstimateHardface : ICommand
{
    public Guid Guid { get; set; }
    public string NotificationFactoryDate { get; set; }
    public string EngineeringCompletionDate { get; set; }
    public string BuyRequestDate { get; set; }
    public int? MaterialPurchaseState { get; set; }
    public string ProjectCompletionForecast { get; set; }
}
