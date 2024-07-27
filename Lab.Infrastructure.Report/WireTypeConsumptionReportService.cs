using Lab.Infrastructure.Report.Contract.WireTypeConsumption;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Report
{
    public class WireTypeConsumptionReportService : IWireTypeConsumptionReportService
    {
        private readonly BaseDapperRepository _repository;

        public WireTypeConsumptionReportService(BaseDapperRepository repository)
        {
            _repository = repository;
        }

        public List<WireTypeConsumptionReportViewModel> GetWireTypeConsumptionReport(WireTypeConsumptionReportSearchModel searchModel) =>
            _repository.SelectFromSp<WireTypeConsumptionReportViewModel>("spWireTypeConsumptionReport", new
            {
                searchModel.Type,
                searchModel.SalonGuid,
                searchModel.ShiftGuid,
                searchModel.FromDate,
                searchModel.ToDate
            });
    }
}