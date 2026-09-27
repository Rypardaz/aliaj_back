using PhoenixFramework.Core;

namespace AM.Infrastructure.Report.Contract.FinalCardProject;

public interface  IFinalCardProjectReportService : IReportService
{
    List<FinalCardProjectReportModel> GetFinalCardProject(FinalCardProjectReportSearchModel searchModel);
}