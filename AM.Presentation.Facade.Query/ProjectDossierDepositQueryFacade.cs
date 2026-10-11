using AM.Application.Contracts.ProjectDossierDeposit;
using AM.Infrastructure.Query.Contract.ProjectDossierDeposit;
using AM.Presentation.Facade.Contract.ProjectDossierDeposit;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class ProjectDossierDepositQueryFacade(IQueryBus queryBus) : IProjectDossierDepositQueryFacade
{
    public List<ProjectDossierDepositViewModel> List() => queryBus.Dispatch<List<ProjectDossierDepositViewModel>>();
    public EditProjectDossierDeposit GetDetails(Guid guid) => queryBus.Dispatch<EditProjectDossierDeposit, Guid>(guid);
}
