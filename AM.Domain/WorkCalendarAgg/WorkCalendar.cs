using PhoenixFramework.Domain;

namespace Ex.Domain.WorkCalendarAgg;

public class WorkCalendar : AggregateRootBase<int>
{
    public long SalonId { get; private set; }
    public string Date { get; private set; }
    public int MonthId { get; private set; }
    public string Month { get; private set; }
    public int Week { get; private set; }
    public int DayId { get; private set; }
    public string Day { get; private set; }
    public int ShiftId { get; private set; }
    public int WorkTime { get; private set; }
    public bool? IsClosed { get; private set; }
    public int? ClosedTypeId { get; private set; }
    public string? Description { get; private set; }

    public string? StartTime { get; set; }
    public string? EndTime { get; set; }

    public WorkCalendar()
    {
    }
}