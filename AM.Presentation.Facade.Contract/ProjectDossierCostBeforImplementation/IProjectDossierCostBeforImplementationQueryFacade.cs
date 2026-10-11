using AM.Application.Contracts.ProjectDossierCostBeforImplementation;
using AM.Infrastructure.Query.Contract.ProjectDossierCostBeforImplementation;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectDossierCostBeforImplementation;

public interface IProjectDossierCostBeforImplementationQueryFacade : IFacadeService
{
    List<ProjectDossierCostBeforImplementationViewModel> List();

    EditProjectDossierCostBeforImplementation GetDetails(Guid guid);
}