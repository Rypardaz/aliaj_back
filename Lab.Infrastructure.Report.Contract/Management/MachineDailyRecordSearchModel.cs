namespace Lab.Infrastructure.Report.Contract.Management
{
    public class MachineDailyRecordSearchModel
    {
        public Guid SalonGuid { get; set; }
        public Guid? ShiftGuid { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public int Type { get; set; }
    }
}