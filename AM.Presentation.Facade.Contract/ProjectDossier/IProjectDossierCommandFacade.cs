using AM.Application.Contracts.ProjectDossier;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.TenderInquiry;

public interface IProjectDossierCommandFacade : IFacadeService
{

    Guid Create(CreateProjectDossier command);

    void Edit(EditProjectDossier command);

    void Delete(Guid guid);

    void Activate(Guid guid);

    void Deactivate(Guid guid);
}
