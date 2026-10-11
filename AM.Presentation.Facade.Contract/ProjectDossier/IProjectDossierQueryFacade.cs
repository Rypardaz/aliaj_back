using AM.Application.Contracts.ProjectDossier;
using AM.Infrastructure.Query.Contract.TenderInquiry;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.TenderInquiry;

public interface IProjectDossierQueryFacade : IFacadeService
{
    List<ProjectDossierViewModel> List();

    EditProjectDossier GetDetails(Guid guid);
    List<ProjectDossierComboModel> Combo(Guid? salonGuid);
}