using PhoenixFramework.Dapper;
using Ex.Application.Contracts.Project;
using PhoenixFramework.Application.Query;
using Lab.Infrastructure.Query.Contracts.Shared;
using Lab.Infrastructure.Query.Contracts.Project;
using Ex.Domain.ProjectAgg;

namespace Lab.Infrastructure.Query
{
    public class ProjectQueryHandler :
        IQueryHandler<List<ProjectViewModel>, ProjectSearchModel>,
        IQueryHandler<EditProject, Guid>,
        IQueryHandler<List<ProjectComboModel>>,
        IQueryHandler<List<ProjectDetailComboModel>, Guid>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public ProjectQueryHandler(BaseDapperRepository dapperRepository) => _dapperRepository = dapperRepository;

        List<ProjectComboModel> IQueryHandler<List<ProjectComboModel>>.Handle() =>
            _dapperRepository.SelectFromSp<ProjectComboModel>(QueryConstants.GetProjectFor, new
            {
                Type = QueryTypes.Combo
            });

        public EditProject Handle(Guid guid)
        {
            var project = _dapperRepository.SelectFromSpFirstOrDefault<EditProject>(QueryConstants.GetProjectFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

            project.Details = _dapperRepository.SelectFromSp<ProjectDetailOperations>(QueryConstants.GetProjectDetailFor, new
            {
                Type = "Edit",
                project.Guid
            });

            return project;
        }

        public List<ProjectViewModel> Handle(ProjectSearchModel searchModel)
        {
            var monthId = searchModel.PeriodId;
            var sessionId = searchModel.PeriodId;

            if (searchModel.SearchType == 1)
                sessionId = 0;

            if (searchModel.SearchType == 2)
                monthId = 0;

            return _dapperRepository.SelectFromSp<ProjectViewModel>(QueryConstants.GetProjectFor, new
            {
                Type = QueryTypes.List,
                MonthId = monthId,
                SessionId = sessionId,
                searchModel.FromDate,
                searchModel.ToDate
            });
        }

        List<ProjectDetailComboModel> IQueryHandler<List<ProjectDetailComboModel>, Guid>.Handle(Guid salonGuid)
        {
            return _dapperRepository.SelectFromSp<ProjectDetailComboModel>(QueryConstants.GetProjectDetailFor, new
            {
                Type = "Combo",
                SalonGuid = salonGuid
            });
        }
    }
}
