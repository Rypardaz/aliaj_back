using AM.Application.Contracts.DailyRecord;
using AM.Infrastructure.Query.Contract.DailyRecord;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.DailyRecord;

public interface IDailyRecordQueryFacade : IFacadeService
{
    List<DailyRecordViewModel> List(DailyRecordSearchModel searchModel);
    EditDailyRecord GetDetails(Guid guid);
    List<DailyRecordComboModel> Combo();
}