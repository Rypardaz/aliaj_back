using PhoenixFramework.Core;
using Lab.Infrastructure.Query.Contracts.WorkCalendar;

namespace Lab.Presentation.Facade.Contract.WorkCalendar
{
    public interface IWorkCalendarQueryFacade : IFacadeService
    {
        List<WorkCalendarViewModel> GetList(WorkCalendarSearchModel searchModel);
    }
}