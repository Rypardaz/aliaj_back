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
    public void EditInquiryInformation(EditInquiryInformation command)
    {
        commandBus.Dispatch(command);
    }
    public void EditContractInformation(EditContractInformation command)
    {
        commandBus.Dispatch(command);
    }
    public void EditCost(EditCost command)
    {
        commandBus.Dispatch(command);
    }
    public void EditInvoice(EditInvoice command)
    {
        commandBus.Dispatch(command);
    }
    public void EditShippingEstimateHardface(EditShippingEstimateHardface command)
    {
        commandBus.Dispatch(command);
    }
    public void EditShippingEstimateRoller(EditShippingEstimateRoller command)
    {
        commandBus.Dispatch(command);
    }
    public void EditCostBeforImplementation(EditCostBeforImplementation command)
    {
        commandBus.Dispatch(command);
    }
    public void EditActualCost(EditActualCost command)
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