namespace Ex.Application.Contracts.Project
{
    public class ProjectDetailOperations
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public Guid ProjectGuid { get; set; }
        public Guid PartGuid { get; set; }
        public string PartCode { get; set; }
        public Guid? GasTypeGuid { get; set; }
        public Guid? WireTypeGuid { get; set; }
        public Guid? WireScrewGuid { get; set; }
        public decimal? WireThickness { get; set; }
        public decimal? WireConsumption { get; set; }
        public Guid? PowderTypeGuid { get; set; }
        public bool IsDeleted { get; set; }
    }
}