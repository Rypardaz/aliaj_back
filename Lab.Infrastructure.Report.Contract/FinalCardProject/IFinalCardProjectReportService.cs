using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.FinalCardProject
{
    public interface  IFinalCardProjectReportService : IReportService
    {
        List<FinalCardProjectReportModel> GetFinalCardProject(FinalCardProjectReportSearchModel searchModel);
    }
}
