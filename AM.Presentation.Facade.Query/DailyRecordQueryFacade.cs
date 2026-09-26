using Ex.Application.Contracts.DailyRecord;
using Lab.Infrastructure.Query.Contracts.DailyRecord;
using Lab.Presentation.Facade.Contract.DailyRecord;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class DailyRecordQueryFacade(IQueryBus queryBus) : IDailyRecordQueryFacade
{
    public List<DailyRecordComboModel> Combo() => queryBus.Dispatch<List<DailyRecordComboModel>>();

    public EditDailyRecord GetDetails(Guid guid) => queryBus.Dispatch<EditDailyRecord, Guid>(guid);

    public List<DailyRecordViewModel> List(DailyRecordSearchModel searchModel) => queryBus.Dispatch<List<DailyRecordViewModel>, DailyRecordSearchModel>(searchModel);
}