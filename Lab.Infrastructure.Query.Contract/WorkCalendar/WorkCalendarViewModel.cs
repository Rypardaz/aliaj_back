namespace Lab.Infrastructure.Query.Contracts.WorkCalendar
{
    public class WorkCalendarViewModel
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public int MonthId { get; set; }
        public string Month { get; set; }
        public int Week { get; set; }
        public int DayId { get; set; }
        public string Day { get; set; }
        public int ShiftId { get; set; }
        public string Shift { get; set; }
        public int WorkTime { get; set; }
        public bool IsClosed { get; set; }
        public int? ClosedTypeId { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? Description { get; set; }
    }
}