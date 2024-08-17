namespace Ex.Application.Contracts.DailyRecord
{
    public class DailyRecordDetailOperations
    {
        public Guid Guid { get; set; }
        public Guid PersonnelGuid { get; set; }
        public Guid ProjectDetailGuid { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public Guid ActivityGuid { get; set; }
        public int ActivityType { get; set; }
        public Guid? GasTypeGuid { get; set; }
        public Guid? PowderTypeGuid { get; set; }
        public Guid? WireTypeGuid { get; set; }
        public string? WireTypeName { get; set; }
        public Guid? WireScrewGuid { get; set; }
        public decimal? WireConsumption { get; set; }
    }
}
