namespace Lab.Infrastructure.Report.Contract.DailyRecordListProductUnitsReport
{
    public class DailyRecordListProductUnitsReportModel
    {
        public string Date { get; set; }
        public string ShiftName { get; set; }
        public string Month { get; set; }
        public string Week { get; set; }
        public string SalonName { get; set; }
        public string MachineName { get; set; }
        public string PersonnelName { get; set; }
        public string PersonnelFamily { get; set; }
        public string PersonnelCode { get; set; }
        public string ActivityTypeName { get; set; }
        public string ActivityTypeCode { get; set; }
        public string ActivityName { get; set; }
        public string ActivitySubType { get; set; }
        public string ActivityCode { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string TotalTime { get; set; }
        public string WireTypeProduced { get; set; }
        public string WireSizeProduced { get; set; }
        public decimal ProducedWire { get; set; }
        public string ProducedScrew { get; set; }
    }
}
