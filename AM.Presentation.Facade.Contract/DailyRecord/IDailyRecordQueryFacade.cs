using Ex.Application.Contracts.DailyRecord;
using Lab.Infrastructure.Query.Contracts.DailyRecord;
using PhoenixFramework.Core;

namespace Lab.Presentation.Facade.Contract.DailyRecord;

public interface IDailyRecordQueryFacade : IFacadeService
{
    List<DailyRecordViewModel> List(DailyRecordSearchModel searchModel);
    EditDailyRecord GetDetails(Guid guid);
    List<DailyRecordComboModel> Combo();
}