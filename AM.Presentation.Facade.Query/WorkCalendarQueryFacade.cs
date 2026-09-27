using AM.Infrastructure.Query.Contract.WorkCalendar;
using AM.Presentation.Facade.Contract.WorkCalendar;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class WorkCalendarQueryFacade(IQueryBus queryBus) : IWorkCalendarQueryFacade
{
    public List<WorkCalendarViewModel> GetList(WorkCalendarSearchModel searchModel)
    {
        return queryBus.Dispatch<List<WorkCalendarViewModel>, WorkCalendarSearchModel>(searchModel);
    }
}