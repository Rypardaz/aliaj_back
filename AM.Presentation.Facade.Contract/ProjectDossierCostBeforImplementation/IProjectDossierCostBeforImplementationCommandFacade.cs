using AM.Application.Contracts.ProjectDossierCostBeforImplementation;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectDossierCostBeforImplementation;

public interface IProjectDossierCostBeforImplementationCommandFacade : IFacadeService
{

    Guid Create(CreateProjectDossierCostBeforImplementation command);

    void Edit(EditProjectDossierCostBeforImplementation command);

    void Delete(Guid guid);
}
