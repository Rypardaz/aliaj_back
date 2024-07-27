namespace Lab.Infrastructure.Report.Contract.ByPart
{
    public class ByPartReportViewModel
    {
        public  string PartGroup { get; set; }
        public string Part { get; set; }
        public string ReportTime { get; set; }
        public string NonProductionStop { get; set; }
        public int TimeInProduction { get; set; }
        public int TimeInProductionPercent { get; set; }
        public int WireConsumption { get; set; }
        public int WireConsumptionPercent { get; set; }
        public decimal AvgConsumption { get; set; }
        public int StandardWireConsumption { get; set; }
        public int StandardProduction { get; set; }
        public int Randeman { get; set; }
    }
}
