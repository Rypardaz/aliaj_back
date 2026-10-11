using AM.Application.Contracts.ProjectDossier;
using AM.Infrastructure.Persist;
using AM.Infrastructure.Query.Contract.ProjectDossierCostBeforImplementation;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class ProjectDossierCostBeforImplementationQueryHandler(
    BaseDapperRepository dapperRepository,
    AliajQueryContext context) :
    IQueryHandler<List<ProjectDossierCostBeforImplementationViewModel>>,
    IQueryHandler<EditProjectDossierCostBeforImplementation, Guid>
{
    List<ProjectDossierCostBeforImplementationViewModel> IQueryHandler<List<ProjectDossierCostBeforImplementationViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<ProjectDossierCostBeforImplementationViewModel>(QueryConstants.GetProjectDossierCostBeforImplementationFor, new
        {
            Type = QueryTypes.List
        });

    public EditProjectDossierCostBeforImplementation Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditProjectDossierCostBeforImplementation>(QueryConstants.GetProjectDossierCostBeforImplementationFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

}