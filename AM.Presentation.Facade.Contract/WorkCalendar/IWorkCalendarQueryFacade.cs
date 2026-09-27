using AM.Infrastructure.Query.Contract.WorkCalendar;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.WorkCalendar;

public interface IWorkCalendarQueryFacade : IFacadeService
{
    List<WorkCalendarViewModel> GetList(WorkCalendarSearchModel searchModel);
}