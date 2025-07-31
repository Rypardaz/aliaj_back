namespace Lab.Infrastructure.Report.Contract.FinalCardProject
{
    public class FinalCardProjectReportSearchModel
    {
        public Guid ProjectGuid { get; set; }
        public Guid? PartGuid { get; set; }
        public string? PartCode { get; set; }
    }
}