using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.ProjectReport;

public interface IProjectReportService : IReportService
{
    List<ProjectWireTypeViewModel> GetProjectWireTypes(ProjectReportSearchModel searchModel);
    List<ProjectReportViewModel> GetProjectReport(ProjectReportSearchModel searchModel);
}