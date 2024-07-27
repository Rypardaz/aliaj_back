using PhoenixFramework.Core;
using Ex.Application.Contracts.WorkCalendar;

namespace Lab.Presentation.Facade.Contract.WorkCalendar
{
    public interface IWorkCalendarCommandFacade : IFacadeService
    {
        void Edit(EditWorkCalendar command);
    }
}