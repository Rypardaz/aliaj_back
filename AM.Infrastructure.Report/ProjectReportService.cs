using PhoenixFramework.Dapper;
using Lab.Infrastructure.Report.Contract.ProjectReport;

namespace Lab.Infrastructure.Report;

public class ProjectReportService(BaseDapperRepository repository) : IProjectReportService
{
    public List<ProjectWireTypeViewModel> GetProjectWireTypes(ProjectReportSearchModel searchModel)
    {
        return repository.SelectFromSp<ProjectWireTypeViewModel>("spProjectReport", new
        {
            ReportType = 0,
            searchModel.ProjectGuid
        });
    }

    public List<ProjectReportViewModel> GetProjectReport(ProjectReportSearchModel searchModel) =>
        repository.SelectFromSp<ProjectReportViewModel>("spProjectReport", new
        {
            ReportType = 1,
            searchModel.ProjectGuid
        });
}