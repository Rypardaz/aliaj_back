using Lab.Infrastructure.Report.Contract.FinalCardProject;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Report
{
    public class FInalCardProjectReportService : IFinalCardProjectReportService
    {
        private readonly BaseDapperRepository _repository;

        public FInalCardProjectReportService(BaseDapperRepository repository)
        {
            _repository = repository;
        }


        public List<FinalCardProjectReportModel> GetFinalCardProject(FinalCardProjectReportSearchModel searchModel)
        {
            return _repository.SelectFromSp<FinalCardProjectReportModel>("spfinalcardproject", new
            {
                searchModel.ProjectGuid
            });
        }
    }
}
