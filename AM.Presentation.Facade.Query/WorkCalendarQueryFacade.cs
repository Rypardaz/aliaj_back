using PhoenixFramework.Application.Query;
using Lab.Presentation.Facade.Contract.WorkCalendar;
using Lab.Infrastructure.Query.Contracts.WorkCalendar;

namespace Lab.Presentation.Facade.Query;

public class WorkCalendarQueryFacade(IQueryBus queryBus) : IWorkCalendarQueryFacade
{
    public List<WorkCalendarViewModel> GetList(WorkCalendarSearchModel searchModel)
    {
        return queryBus.Dispatch<List<WorkCalendarViewModel>, WorkCalendarSearchModel>(searchModel);
    }
}