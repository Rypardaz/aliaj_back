using AM.Application.Contracts.ProjectDossierDeposit;
using AM.Infrastructure.Persist;
using AM.Infrastructure.Query.Contract.ProjectDossierDeposit;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class ProjectDossierDepositQueryHandler(
    BaseDapperRepository dapperRepository,
    AliajQueryContext context) :
    IQueryHandler<List<ProjectDossierDepositViewModel>>,
    IQueryHandler<EditProjectDossierDeposit, Guid>
{
    List<ProjectDossierDepositViewModel> IQueryHandler<List<ProjectDossierDepositViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<ProjectDossierDepositViewModel>(QueryConstants.GetProjectDossierDepositFor, new
        {
            Type = QueryTypes.List
        });

    public EditProjectDossierDeposit Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditProjectDossierDeposit>(QueryConstants.GetProjectDossierDepositFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

}