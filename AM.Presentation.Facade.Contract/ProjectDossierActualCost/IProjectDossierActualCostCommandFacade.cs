using AM.Application.Contracts.ProjectDossierActualCost;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectDossierActualCost;

public interface IProjectDossierActualCostCommandFacade : IFacadeService
{

    Guid Create(CreateProjectDossierActualCost command);

    void Edit(EditProjectDossierActualCost command);

    void Delete(Guid guid);
}
