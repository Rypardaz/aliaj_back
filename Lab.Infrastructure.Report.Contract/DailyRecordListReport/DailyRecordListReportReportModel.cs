namespace Lab.Infrastructure.Report.Contract.DailyRecordListReport
{
    public class DailyRecordListReportModel
    {
        public string Date { get; set; }
        public string Shift { get; set; }
        public string Month { get; set; }
        public string Week { get; set; }
        public string Salon { get; set; }
        public string Machine { get; set; }
        public int head { get; set; }
        public string PersonnelName { get; set; }
        public string PersonnelFamily { get; set; }
        public string PersonnelCode { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string TaskMasterName { get; set; }
        public string PartGroupName { get; set; }
        public string PartName { get; set; }
        public string PartCode { get; set; }
        public string ActivityTypeName { get; set; }
        public int ActivityType { get; set; }
        public string ActivityName { get; set; }
        public string ActivitySubType { get; set; }
        public string ActivityCode { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public decimal TotalTime { get; set; }
        public int TotalTimeByMin { get; set; }
        public string GasTypeName { get; set; }
        public string PowderTypeName { get; set; }
        public string WireTypeGroupName { get; set; }
        public string WireTypeName { get; set; }
        public string WireSize { get; set; }
        public string Screw { get; set; }
        public string WireConsumption { get; set; }
        public string Description { get; set; }
    }
}
