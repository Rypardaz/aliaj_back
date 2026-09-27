using AM.Application.Contracts.DailyRecord;
using AM.Infrastructure.Query.Contract.DailyRecord;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class DailyRecordQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<DailyRecordViewModel>, DailyRecordSearchModel>,
    IQueryHandler<EditDailyRecord, Guid>,
    IQueryHandler<List<DailyRecordComboModel>>
{
    public List<DailyRecordViewModel> Handle(DailyRecordSearchModel searchModel)
    {
        var monthId = searchModel.PeriodId;
        var sessionId = searchModel.PeriodId;

        if (searchModel.SearchType == 1)
            sessionId = 0;

        if (searchModel.SearchType == 2)
            monthId = 0;

        return dapperRepository.SelectFromSp<DailyRecordViewModel>(QueryConstants.GetDailyRecordFor, new
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
        return dapperRepository.SelectFromSp<DailyRecordComboModel>(QueryConstants.GetDailyRecordFor, new
        {
            Type = QueryTypes.Combo
        });
    }

    public EditDailyRecord Handle(Guid guid)
    {
        var dailyRecord = dapperRepository.SelectFromSpFirstOrDefault<EditDailyRecord>(QueryConstants.GetDailyRecordFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

        dailyRecord.Details = dapperRepository.SelectFromSp<DailyRecordDetailOperations>("spGetDailyRecordDetail", new
        {
            dailyRecord.Guid
        });

        return dailyRecord;
    }
}