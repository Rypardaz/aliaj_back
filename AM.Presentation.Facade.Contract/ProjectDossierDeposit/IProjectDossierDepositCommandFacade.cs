using AM.Application.Contracts.ProjectDossierDeposit;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectDossierDeposit;

public interface IProjectDossierDepositCommandFacade : IFacadeService
{

    Guid Create(CreateProjectDossierDeposit command);

    void Edit(EditProjectDossierDeposit command);

    void Delete(Guid guid);
}
