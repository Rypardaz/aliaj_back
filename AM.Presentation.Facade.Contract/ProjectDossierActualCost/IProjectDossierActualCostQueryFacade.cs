using AM.Application.Contracts.ProjectDossierActualCost;
using AM.Infrastructure.Query.Contract.ProjectDossierActualCost;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectDossierActualCost;

public interface IProjectDossierActualCostQueryFacade : IFacadeService
{
    List<ProjectDossierActualCostViewModel> List();

    EditProjectDossierActualCost GetDetails(Guid guid);
}