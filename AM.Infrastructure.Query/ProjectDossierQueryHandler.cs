using AM.Application.Contracts.ProjectDossier;
using AM.Infrastructure.Persist;
using AM.Infrastructure.Query.Contract.ProjectDossier;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class ProjectDossierQueryHandler(
    BaseDapperRepository dapperRepository,
    AliajQueryContext context) :
    IQueryHandler<List<ProjectDossierViewModel>>,
    IQueryHandler<EditProjectDossier, Guid>,
    IQueryHandler<List<ProjectDossierComboModel>, Guid?>
{
    List<ProjectDossierViewModel> IQueryHandler<List<ProjectDossierViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<ProjectDossierViewModel>(QueryConstants.GetProjectDossierFor, new
        {
            Type = QueryTypes.List
        });

    public List<ProjectDossierComboModel> Handle(Guid? salonGuid)
    {
        return dapperRepository.SelectFromSp<ProjectDossierComboModel>(QueryConstants.GetProjectDossierFor, new
        {
            Type = QueryTypes.Combo,
            SalonGuid = salonGuid
        });
    }
    public EditProjectDossier Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditProjectDossier>(QueryConstants.GetProjectDossierFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });
}