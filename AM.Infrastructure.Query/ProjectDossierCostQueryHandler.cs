using AM.Application.Contracts.ProjectDossierCost;
using AM.Infrastructure.Persist;
using AM.Infrastructure.Query.Contract.ProjectDossierCost;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class ProjectDossierCostQueryHandler(
    BaseDapperRepository dapperRepository,
    AliajQueryContext context) :
    IQueryHandler<List<ProjectDossierCostViewModel>>,
    IQueryHandler<EditProjectDossierCost, Guid>
{
    List<ProjectDossierCostViewModel> IQueryHandler<List<ProjectDossierCostViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<ProjectDossierCostViewModel>(QueryConstants.GetProjectDossierCostFor, new
        {
            Type = QueryTypes.List
        });

    public EditProjectDossierCost Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditProjectDossierCost>(QueryConstants.GetProjectDossierCostFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

}