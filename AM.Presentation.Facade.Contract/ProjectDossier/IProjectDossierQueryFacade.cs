using AM.Application.Contracts.ProjectDossier;
using AM.Infrastructure.Query.Contract.ProjectDossier;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectDossier;

public interface IProjectDossierQueryFacade : IFacadeService
{
    List<ProjectDossierViewModel> List();

    EditProjectDossier GetDetails(Guid guid);
    List<ProjectDossierComboModel> Combo(Guid? salonGuid);
}