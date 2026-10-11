using AM.Application.Contracts.ProjectDossierCost;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectDossierCost;

public interface IProjectDossierCostCommandFacade : IFacadeService
{

    Guid Create(CreateProjectDossierCost command);

    void Edit(EditProjectDossierCost command);

    void Delete(Guid guid);
}
