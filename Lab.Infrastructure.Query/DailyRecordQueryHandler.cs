using Ex.Application.Contracts.DailyRecord;
using Ex.Application.Contracts.Project;
using Ex.Domain.ProjectAgg;
using Lab.Infrastructure.Query.Contracts.DailyRecord;
using Lab.Infrastructure.Query.Contracts.Project;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query
{
    public class DailyRecordQueryHandler :
    IQueryHandler<List<DailyRecordViewModel>, DailyRecordSearchModel>,
    IQueryHandler<EditDailyRecord, Guid>,
    IQueryHandler<List<DailyRecordComboModel>>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public DailyRecordQueryHandler(BaseDapperRepository dapperRepository)
        {

            _dapperRepository = dapperRepository;
        }

        public List<DailyRecordViewModel> Handle(DailyRecordSearchModel searchModel)
        {
            var monthId = searchModel.PeriodId;
            var sessionId = searchModel.PeriodId;

            if (searchModel.SearchType == 1)
                sessionId = 0;

            if (searchModel.SearchType == 2)
                monthId = 0;

            return _dapperRepository.SelectFromSp<DailyRecordViewModel>(QueryConstants.GetDailyRecordFor, new
            {
                Type = QueryTypes.List,
                searchModel.SalonGuid,
                MonthId = monthId,
                SessionId = sessionId,
                searchModel.FromDate,
                searchModel.ToDate
            });
        }

        List<DailyRecordComboModel> IQueryHandler<List<DailyRecordComboModel>>.Handle()
        {
            return _dapperRepository.SelectFromSp<DailyRecordComboModel>(QueryConstants.GetDailyRecordFor, new
            {
                Type = QueryTypes.Combo
            });
        }

        public EditDailyRecord Handle(Guid guid)
        {
            var dailyRecord = _dapperRepository.SelectFromSpFirstOrDefault<EditDailyRecord>(QueryConstants.GetDailyRecordFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

            dailyRecord.Details = _dapperRepository.SelectFromSp<DailyRecordDetailOperations>("spGetDailyRecordDetail", new
            {
                dailyRecord.Guid
            });

            return dailyRecord;
        }
    }
}
