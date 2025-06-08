using PhoenixFramework.Dapper;
using Lab.Infrastructure.Report.Contract.ProjectReport;

namespace Lab.Infrastructure.Report;

public class ProjectReportService : IProjectReportService
{
    private readonly BaseDapperRepository _repository;

    public ProjectReportService(BaseDapperRepository repository)
    {
        _repository = repository;
    }

    public List<ProjectWireTypeViewModel> GetProjectWireTypes(ProjectReportSearchModel searchModel)
    {
        return _repository.SelectFromSp<ProjectWireTypeViewModel>("spProjectReport", new
        {
            ReportType = 0,
            searchModel.ProjectGuid
        });
    }

    public List<ProjectReportViewModel> GetProjectReport(ProjectReportSearchModel searchModel) =>
        _repository.SelectFromSp<ProjectReportViewModel>("spProjectReport", new
        {
            ReportType = 1,
            searchModel.ProjectGuid
        });
}