using AM.Application.Contracts.ProjectType;
using AM.Infrastructure.Query.Contract.ProjectType;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class ProjectTypeQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<ProjectTypeViewModel>>,
    IQueryHandler<EditProjectType, Guid>,
    IQueryHandler<List<ProjectTypeComboModel>, Guid>
{
    List<ProjectTypeViewModel> IQueryHandler<List<ProjectTypeViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<ProjectTypeViewModel>(QueryConstants.GetProjectTypeFor, new
        {
            Type = QueryTypes.List
        });

    public EditProjectType Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditProjectType>(QueryConstants.GetProjectTypeFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

    List<ProjectTypeComboModel> IQueryHandler<List<ProjectTypeComboModel>, Guid>.Handle(Guid salonGuid) =>
        dapperRepository.SelectFromSp<ProjectTypeComboModel>(QueryConstants.GetProjectTypeFor, new
        {
            Type = QueryTypes.Combo,
            SalonGuid = salonGuid
        });
}