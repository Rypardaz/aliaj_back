using AM.Application.Contracts.ProjectDossierCost;
using AM.Infrastructure.Query.Contract.ProjectDossierCost;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectDossierCost;

public interface IProjectDossierCostQueryFacade : IFacadeService
{
    List<ProjectDossierCostViewModel> List();

    EditProjectDossierCost GetDetails(Guid guid);
}