using AM.Application.Contracts.ProjectDossierActualCost;
using AM.Infrastructure.Persist;
using AM.Infrastructure.Query.Contract.ProjectDossierActualCost;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class ProjectDossierActualCostQueryHandler(
    BaseDapperRepository dapperRepository,
    AliajQueryContext context) :
    IQueryHandler<List<ProjectDossierActualCostViewModel>>,
    IQueryHandler<EditProjectDossierActualCost, Guid>
{
    List<ProjectDossierActualCostViewModel> IQueryHandler<List<ProjectDossierActualCostViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<ProjectDossierActualCostViewModel>(QueryConstants.GetProjectDossierActualCostFor, new
        {
            Type = QueryTypes.List
        });

    public EditProjectDossierActualCost Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditProjectDossierActualCost>(QueryConstants.GetProjectDossierActualCostFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

}
