using Lab.Infrastructure.Report.Contract.Activity;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Report
{
    public class ActivityReportService : IActivityReportService
    {
        private readonly BaseDapperRepository _repository;

        public ActivityReportService(BaseDapperRepository repository)
        {
            _repository = repository;
        }

        public List<ActivityReportViewModel> GetActivityReport(ActivityReportSearchModel searchModel) =>
            _repository.SelectFromSp<ActivityReportViewModel>("spActivityReport", new
            {
                searchModel.SalonGuid,
                searchModel.ActivitySubType,
                searchModel.SourceGuid,
                searchModel.WeekId,
                searchModel.MonthId,
                searchModel.FromDate,
                searchModel.ToDate
            });
    }
}