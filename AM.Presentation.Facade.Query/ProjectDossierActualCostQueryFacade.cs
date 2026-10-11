using AM.Application.Contracts.ProjectDossierActualCost;
using AM.Infrastructure.Query.Contract.ProjectDossierActualCost;
using AM.Presentation.Facade.Contract.ProjectDossierActualCost;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class ProjectDossierActualCostQueryFacade(IQueryBus queryBus) : IProjectDossierActualCostQueryFacade
{
    public List<ProjectDossierActualCostViewModel> List() => queryBus.Dispatch<List<ProjectDossierActualCostViewModel>>();
    public EditProjectDossierActualCost GetDetails(Guid guid) => queryBus.Dispatch<EditProjectDossierActualCost, Guid>(guid);
}
