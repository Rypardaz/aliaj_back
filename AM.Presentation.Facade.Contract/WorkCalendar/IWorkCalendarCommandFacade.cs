using AM.Application.Contracts.WorkCalendar;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.WorkCalendar;

public interface IWorkCalendarCommandFacade : IFacadeService
{
    void Edit(EditWorkCalendar command);
}