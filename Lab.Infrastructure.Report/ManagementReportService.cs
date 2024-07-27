using PhoenixFramework.Dapper;
using Lab.Infrastructure.Report.Contract;
using Lab.Infrastructure.Report.Contract.Management;

namespace Lab.Infrastructure.Report
{
    public class ManagementReportService : IManagementReportService
    {
        private readonly BaseDapperRepository _repository;

        public ManagementReportService(BaseDapperRepository repository)
        {
            _repository = repository;
        }

        public List<ActivityNameViewModel> GetActivityNames(Guid salonGuid)
        {
            return _repository.SelectFromSp<ActivityNameViewModel>("spDailyReport", new
            {
                Type = 0,
                SalonGuid = salonGuid
            });
        }

        public List<MachineDailyRecordViewModel> GetMachineDailyRecordReport(MachineDailyRecordSearchModel searchModel) => 
            _repository.SelectFromSp<MachineDailyRecordViewModel>("spDailyReport", new
        {
            searchModel.Type,
            searchModel.SalonGuid,
            searchModel.ShiftGuid,
            searchModel.FromDate,
            searchModel.ToDate
        });
    }
}