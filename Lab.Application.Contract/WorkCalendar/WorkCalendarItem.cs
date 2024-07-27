namespace Ex.Application.Contracts.WorkCalendar;

public class WorkCalendarItem
{
    public long Id { get; set; }
    public int ShiftId { get; set; }
    public int WorkTime { get; set; }
    public bool IsClosed { get; set; }
    public int? ClosedTypeId { get; set; }
    public string? Description { get; set; }
}
