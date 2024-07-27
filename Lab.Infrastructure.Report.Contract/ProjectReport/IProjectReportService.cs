using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.ProjectReport
{
    public interface IProjectReportService : IReportService
    {
        List<ProjectReportViewModel> GetProjectReport(ProjectReportSearchModel searchModel);
    }

}
