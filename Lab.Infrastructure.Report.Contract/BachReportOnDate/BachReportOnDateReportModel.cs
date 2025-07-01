namespace Lab.Infrastructure.Report.Contract.BachReportOnDate
{
    public class BachReportOnDateReportModel
    {
        public string Date { get; set; }
        public string ShiftName { get; set; }
        public string SalonName { get; set; }
        public string MachineName { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string PartCode { get; set; }
        public string PartGroupName { get; set; }
        public string PartType { get; set; }
        public string WireTypeName { get; set; }
        public string Screw { get; set; }
        public decimal WireConsumption { get; set; }
    }
}
