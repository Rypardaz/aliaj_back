using PhoenixFramework.Application.Query;
using Lab.Presentation.Facade.Contract.WorkCalendar;
using Lab.Infrastructure.Query.Contracts.WorkCalendar;

namespace Lab.Presentation.Facade.Query
{
    public class WorkCalendarQueryFacade : IWorkCalendarQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public WorkCalendarQueryFacade(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        public List<WorkCalendarViewModel> GetList(WorkCalendarSearchModel searchModel)
        {
            return _queryBus.Dispatch<List<WorkCalendarViewModel>, WorkCalendarSearchModel>(searchModel);
        }
    }
}
