using AM.Application.Contracts.ProjectDossierCost;
using AM.Infrastructure.Query.Contract.ProjectDossierCost;
using AM.Presentation.Facade.Contract.ProjectDossierCost;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class ProjectDossierCostQueryFacade(IQueryBus queryBus) : IProjectDossierCostQueryFacade
{
    public List<ProjectDossierCostViewModel> List() => queryBus.Dispatch<List<ProjectDossierCostViewModel>>();
    public EditProjectDossierCost GetDetails(Guid guid) => queryBus.Dispatch<EditProjectDossierCost, Guid>(guid);
}
