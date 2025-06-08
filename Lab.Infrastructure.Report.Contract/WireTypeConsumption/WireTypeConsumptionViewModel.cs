namespace Lab.Infrastructure.Report.Contract.WireTypeConsumption
{
    public class WireTypeConsumptionReportViewModel
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Title { get; set; }
        public string WireType { get; set; }
        public string ShiftTitle { get; set; }
        public decimal WireConsumption { get; set; }
    }
}
