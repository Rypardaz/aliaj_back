using Ex.Application.Contracts.ProjectType;
using Lab.Infrastructure.Query.Contracts.ProjectType;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;
using System;

namespace Lab.Infrastructure.Query;

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