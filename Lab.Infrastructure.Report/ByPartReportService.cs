using Lab.Infrastructure.Report.Contract.ByPart;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Report
{
    public class ByPartReportService: IByPartReportService
    {
        private readonly BaseDapperRepository _repository;

        public ByPartReportService(BaseDapperRepository repository)
        {
            _repository = repository;
        }

        public List<ByPartReportViewModel> GetByPartReport(ByPartReportSearchModel searchModel) =>
            _repository.SelectFromSp<ByPartReportViewModel>("spByPartReport", new
            {
                searchModel.SalonGuid,
                searchModel.WeekId,
                searchModel.MonthId,
                searchModel.FromDate,
                searchModel.ToDate
            });
    }
}