namespace AM.Infrastructure.Query.Contract.WorkCalendar;

public class WorkCalendarSearchModel
{
    public Guid SalonGuid { get; set; }
    public int YearId { get; set; }
    public int MonthId { get; set; }
}