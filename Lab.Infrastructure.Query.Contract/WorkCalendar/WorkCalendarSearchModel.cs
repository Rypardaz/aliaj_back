namespace Lab.Infrastructure.Query.Contracts.WorkCalendar
{
    public class WorkCalendarSearchModel
    {
        public Guid SalonGuid { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }
    }
}