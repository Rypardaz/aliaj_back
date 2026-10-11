using AM.Application.Contracts.ProjectDossier;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.TenderInquiry;

public interface IProjectDossierCommandFacade : IFacadeService
{

    Guid Create(CreateProjectDossier command);

    void Edit(EditProjectDossier command);
    void EditInquiryInformation(EditInquiryInformation command);
    void EditContractInformation(EditContractInformation command);
    void EditCost(EditCost command);
    void EditInvoice(EditInvoice command);
    void EditShippingEstimateHardface(EditShippingEstimateHardface command);
    void EditShippingEstimateRoller(EditShippingEstimateRoller command);
    void EditCostBeforImplementation(EditCostBeforImplementation command);
    void EditActualCost(EditActualCost command);
    
    void Delete(Guid guid);

    void Activate(Guid guid);

    void Deactivate(Guid guid);
}
