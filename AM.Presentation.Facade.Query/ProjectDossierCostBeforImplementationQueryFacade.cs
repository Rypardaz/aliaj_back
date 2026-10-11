using AM.Application.Contracts.ProjectDossierCostBeforImplementation;
using AM.Infrastructure.Query.Contract.ProjectDossierCostBeforImplementation;
using AM.Presentation.Facade.Contract.ProjectDossierCostBeforImplementation;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class ProjectDossierCostBeforImplementationQueryFacade(IQueryBus queryBus) : IProjectDossierCostBeforImplementationQueryFacade
{
    public List<ProjectDossierCostBeforImplementationViewModel> List() => queryBus.Dispatch<List<ProjectDossierCostBeforImplementationViewModel>>();
    public EditProjectDossierCostBeforImplementation GetDetails(Guid guid) => queryBus.Dispatch<EditProjectDossierCostBeforImplementation, Guid>(guid);
}
