using Lab.Infrastructure.Report.Contract.ProjectReport;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Report
{
    public class ProjectReportService : IProjectReportService
    {
        private readonly BaseDapperRepository _repository;

        public ProjectReportService(BaseDapperRepository repository)
        {
            _repository = repository;
        }

        public List<ProjectReportViewModel> GetProjectReport(ProjectReportSearchModel searchModel) =>
            _repository.SelectFromSp<ProjectReportViewModel>("spProjectReport", new
            {
                searchModel.ProjectGuid,
            });
    }
}

