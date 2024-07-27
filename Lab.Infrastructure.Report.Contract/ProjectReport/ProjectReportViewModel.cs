namespace Lab.Infrastructure.Report.Contract.ProjectReport
{
    public class ProjectReportViewModel
    {
        public string PartGroup { get; set; }
        public string Part { get; set; }
        public string PartCode { get; set; }
        public  string PersonnelTime { get; set; }
        public int StandartWireConsumption { get; set; }
        public int WireConsumption { get; set; }
        public int ConsumptionPercent { get; set; }
    }

}
