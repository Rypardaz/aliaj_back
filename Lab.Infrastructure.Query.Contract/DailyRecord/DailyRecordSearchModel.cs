namespace Lab.Infrastructure.Query.Contracts.DailyRecord
{
    public class DailyRecordSearchModel
    {
        public Guid SalonGuid { get; set; }
        public int PeriodId { get; set; }
        public int SearchType { get; set; } // 1, 2, 3
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
    }
}
