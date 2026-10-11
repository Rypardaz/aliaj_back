using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossier;

public class EditProjectDossierShippingEstimateRoller : ICommand
{
    public Guid Guid { get; set; }
    public int? TypeOfCargo { get; set; }
    public string JoiningToFactoryDate { get; set; }
    public string SendingDeadlineToTaskMaster { get; set; }
    public string EstimatedShippingDateFromEshtehard { get; set; }
    public string EstimatedDeliveryDateToClient { get; set; }
    public string ActualShippingDateFromEshtehard { get; set; }
    public string ActualDeliveryDateToClient { get; set; }
}
