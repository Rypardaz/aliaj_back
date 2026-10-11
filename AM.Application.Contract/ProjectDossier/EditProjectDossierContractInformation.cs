using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossier;

public class EditProjectDossierContractInformation : ICommand
{
    public Guid Guid { get; set; }
    public string ContractDate { get; set; }
    public long? ContractAmount { get; set; }
    public int? DownPaymentPercentage { get; set; }
    public string ContractDeliveryDate { get; set; }
    public string EmployerNotificationDate { get; set; }
}
