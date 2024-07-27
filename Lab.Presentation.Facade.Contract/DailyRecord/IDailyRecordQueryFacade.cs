using Ex.Application.Contracts.DailyRecord;
using Lab.Infrastructure.Query.Contracts.DailyRecord;
using Lab.Infrastructure.Query.Contracts.Project;
using PhoenixFramework.Core;

namespace Ex.Application.Contracts.DailyRecord
{
    public interface IDailyRecordQueryFacade : IFacadeService
    {
        List<DailyRecordViewModel> List(DailyRecordSearchModel searchModel);
        EditDailyRecord GetDetails(Guid guid);
        List<DailyRecordComboModel> Combo();
    }
}
