using AM.Application.Contracts.ProjectDossierProduct;
using AM.Infrastructure.Persist;
using AM.Infrastructure.Query.Contract.ProjectDossierProduct;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class ProjectDossierProductQueryHandler(
    BaseDapperRepository dapperRepository,
    AliajQueryContext context) :
    IQueryHandler<List<ProjectDossierProductViewModel>>,
    IQueryHandler<EditProjectDossierProduct, Guid>
{
    List<ProjectDossierProductViewModel> IQueryHandler<List<ProjectDossierProductViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<ProjectDossierProductViewModel>(QueryConstants.GetProjectDossierProductFor, new
        {
            Type = QueryTypes.List
        });

    public EditProjectDossierProduct Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditProjectDossierProduct>(QueryConstants.GetProjectDossierProductFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

}