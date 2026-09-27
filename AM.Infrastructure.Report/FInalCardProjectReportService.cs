using AM.Infrastructure.Report.Contract.FinalCardProject;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Report;

public class FInalCardProjectReportService(BaseDapperRepository repository) : IFinalCardProjectReportService
{
    public List<FinalCardProjectReportModel> GetFinalCardProject(FinalCardProjectReportSearchModel searchModel)
    {
        return repository.SelectFromSp<FinalCardProjectReportModel>("spfinalcardproject", new
        {
            searchModel.ProjectGuid,
            searchModel.PartGuid,
            searchModel.PartCode
        });
    }
}