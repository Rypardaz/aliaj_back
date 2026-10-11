using AM.Application.Contracts.ProjectDossierProduct;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectDossierProduct;

public interface IProjectDossierProductCommandFacade : IFacadeService
{

    Guid Create(CreateProjectDossierProduct command);

    void Edit(EditProjectDossierProduct command);

    void Delete(Guid guid);
}
