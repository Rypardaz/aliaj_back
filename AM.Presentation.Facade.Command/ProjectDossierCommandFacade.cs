using AM.Application.Contracts.ProjectDossier;
using AM.Presentation.Facade.Contract.TenderInquiry;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class ProjectDossierCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : IProjectDossierCommandFacade
{
    public Guid Create(CreateProjectDossier command)
    {
        return responsiveCommandBus.Dispatch<CreateProjectDossier, Guid>(command);
    }

    public void Edit(EditProjectDossier command)
    {
        commandBus.Dispatch(command);
    }
    public void EditInquiryInformation(EditProjectDossierInquiryInformation command)
    {
        commandBus.Dispatch(command);
    }
    public void EditContractInformation(EditProjectDossierContractInformation command)
    {
        commandBus.Dispatch(command);
    }
    public void EditCost(EditProjectDossierCost command)
    {
        commandBus.Dispatch(command);
    }
    public void EditInvoice(EditProjectDossierInvoice command)
    {
        commandBus.Dispatch(command);
    }
    public void EditShippingEstimateHardface(EditProjectDossierShippingEstimateHardface command)
    {
        commandBus.Dispatch(command);
    }
    public void EditShippingEstimateRoller(EditProjectDossierShippingEstimateRoller command)
    {
        commandBus.Dispatch(command);
    }
    public void EditCostBeforImplementation(EditProjectDossierCostBeforImplementation command)
    {
        commandBus.Dispatch(command);
    }
    public void EditActualCost(EditProjectDossierActualCost command)
    {
        commandBus.Dispatch(command);
    }

    public void Deactivate(Guid guid)
    {
        var com = new DeactivateProjectDossier(guid);
        commandBus.Dispatch(com);
    }

    public void Activate(Guid guid)
    {
        var com = new ActivateProjectDossier(guid);
        commandBus.Dispatch(com);
    }

    public void Delete(Guid guid)
    {
        var com = new RemoveProjectDossier(guid);
        commandBus.Dispatch(com);
    }
}