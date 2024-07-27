using Ex.Application.Contracts.ProjectType;
using Lab.Infrastructure.Query.Contracts.ProjectType;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;
using System;

namespace Lab.Infrastructure.Query
{
    public class ProjectTypeQueryHandler :
    IQueryHandler<List<ProjectTypeViewModel>>,
    IQueryHandler<EditProjectType, Guid>,
    IQueryHandler<List<ProjectTypeComboModel>, Guid>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public ProjectTypeQueryHandler(BaseDapperRepository dapperRepository)
        {

            _dapperRepository = dapperRepository;
        }

        List<ProjectTypeViewModel> IQueryHandler<List<ProjectTypeViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<ProjectTypeViewModel>(QueryConstants.GetProjectTypeFor, new
            {
                Type = QueryTypes.List
            });

        public EditProjectType Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditProjectType>(QueryConstants.GetProjectTypeFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

        List<ProjectTypeComboModel> IQueryHandler<List<ProjectTypeComboModel>, Guid>.Handle(Guid salonGuid) =>
            _dapperRepository.SelectFromSp<ProjectTypeComboModel>(QueryConstants.GetProjectTypeFor, new
            {
                Type = QueryTypes.Combo,
                SalonGuid = salonGuid
            });
    }
}