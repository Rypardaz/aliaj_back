using AM.Application.Contracts.ProjectDossierProduct;
using AM.Infrastructure.Query.Contract.ProjectDossierProduct;
using AM.Presentation.Facade.Contract.ProjectDossierProduct;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class ProjectDossierProductQueryFacade(IQueryBus queryBus) : IProjectDossierProductQueryFacade
{
    public List<ProjectDossierProductViewModel> List() => queryBus.Dispatch<List<ProjectDossierProductViewModel>>();
    public EditProjectDossierProduct GetDetails(Guid guid) => queryBus.Dispatch<EditProjectDossierProduct, Guid>(guid);
}
