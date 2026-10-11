using AM.Application.Contracts.ProjectDossierDeposit;
using AM.Infrastructure.Query.Contract.ProjectDossierDeposit;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectDossierDeposit;

public interface IProjectDossierDepositQueryFacade : IFacadeService
{
    List<ProjectDossierDepositViewModel> List();

    EditProjectDossierDeposit GetDetails(Guid guid);
}