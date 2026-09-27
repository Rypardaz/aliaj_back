using AM.Application.Contracts.DailyRecord;
using AM.Infrastructure.Query.Contract.DailyRecord;
using AM.Presentation.Facade.Contract.DailyRecord;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class DailyRecordQueryFacade(IQueryBus queryBus) : IDailyRecordQueryFacade
{
    public List<DailyRecordComboModel> Combo() => queryBus.Dispatch<List<DailyRecordComboModel>>();

    public EditDailyRecord GetDetails(Guid guid) => queryBus.Dispatch<EditDailyRecord, Guid>(guid);

    public List<DailyRecordViewModel> List(DailyRecordSearchModel searchModel) => queryBus.Dispatch<List<DailyRecordViewModel>, DailyRecordSearchModel>(searchModel);
}