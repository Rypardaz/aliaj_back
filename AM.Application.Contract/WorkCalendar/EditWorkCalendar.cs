using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.WorkCalendar;

public class EditWorkCalendar : ICommand
{
    public List<WorkCalendarItem> Items { get; set; }
}
