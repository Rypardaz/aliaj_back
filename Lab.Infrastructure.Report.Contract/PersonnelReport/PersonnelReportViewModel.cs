namespace Lab.Infrastructure.Report.Contract.PersonnelReport
{
    public class PersonnelReportViewModel
    {
        public string PartGroup { get; set; }
        public string Part { get; set; }
        public string PartCode { get; set; }
        public string PersonnelTime { get; set; }
        public int WireConsumption { get; set; }
        public decimal AvgWireConsumption { get; set; }
        public  int StandartWireConsumptionPart { get; set; }
        public  decimal StandartWireConsumption { get; set; }
        public  int ConsumptionPercent{ get; set; }
    }
}
