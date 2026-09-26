using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WorkCalendar;

public class EditWorkCalendar : ICommand
{
    public List<WorkCalendarItem> Items { get; set; }
}
