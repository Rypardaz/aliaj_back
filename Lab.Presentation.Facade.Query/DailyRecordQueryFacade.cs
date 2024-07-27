using Ex.Application.Contracts.DailyRecord;
using Lab.Infrastructure.Query.Contracts.DailyRecord;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class DailyRecordQueryFacade : IDailyRecordQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public DailyRecordQueryFacade(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        public List<DailyRecordComboModel> Combo() => _queryBus.Dispatch<List<DailyRecordComboModel>>();

        public EditDailyRecord GetDetails(Guid guid) => _queryBus.Dispatch<EditDailyRecord, Guid>(guid);

        public List<DailyRecordViewModel> List(DailyRecordSearchModel searchModel) => _queryBus.Dispatch<List<DailyRecordViewModel>, DailyRecordSearchModel>(searchModel);
    }
}
