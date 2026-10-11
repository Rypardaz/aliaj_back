using AM.Application.Contracts.ProjectDossier;
using AM.Infrastructure.Query.Contract.TenderInquiry;
using AM.Presentation.Facade.Contract.TenderInquiry;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class ProjectDossierQueryFacade(IQueryBus queryBus) : IProjectDossierQueryFacade
{
    public EditProjectDossier GetDetails(Guid guid) => queryBus.Dispatch<EditProjectDossier, Guid>(guid);

    public List<ProjectDossierViewModel> List() => queryBus.Dispatch<List<ProjectDossierViewModel>>();

    public List<ProjectDossierComboModel> Combo(Guid? salonGuid) =>
        queryBus.Dispatch<List<ProjectDossierComboModel>, Guid?>(salonGuid);
}