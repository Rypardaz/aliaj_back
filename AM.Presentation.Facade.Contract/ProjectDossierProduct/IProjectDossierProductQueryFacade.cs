using AM.Application.Contracts.ProjectDossierProduct;
using AM.Infrastructure.Query.Contract.ProjectDossierProduct;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectDossierProduct;

public interface IProjectDossierProductQueryFacade : IFacadeService
{
    List<ProjectDossierProductViewModel> List();

    EditProjectDossierProduct GetDetails(Guid guid);
}