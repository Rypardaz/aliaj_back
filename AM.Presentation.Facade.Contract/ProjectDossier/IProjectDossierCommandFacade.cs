using AM.Application.Contracts.ProjectDossier;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.TenderInquiry;

public interface IProjectDossierCommandFacade : IFacadeService
{

    Guid Create(CreateProjectDossier command);

    void Edit(EditProjectDossier command);
    void EditInquiryInformation(EditProjectDossierInquiryInformation command);
    void EditContractInformation(EditProjectDossierContractInformation command);
    void EditCost(EditProjectDossierCost command);
    void EditInvoice(EditProjectDossierInvoice command);
    void EditShippingEstimateHardface(EditProjectDossierShippingEstimateHardface command);
    void EditShippingEstimateRoller(EditProjectDossierShippingEstimateRoller command);
    void EditCostBeforImplementation(EditProjectDossierCostBeforImplementation command);
    void EditActualCost(EditProjectDossierActualCost command);
    
    void Delete(Guid guid);

    void Activate(Guid guid);

    void Deactivate(Guid guid);
}
