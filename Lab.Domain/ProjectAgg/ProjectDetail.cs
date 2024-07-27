using PhoenixFramework.Domain;

namespace Ex.Domain.ProjectAgg
{
    public record ProjectDetail : ValueObjectBase
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public long ProjectId { get; set; }
        public long PartId { get; set; }
        public string PartCode { get; private set; }
        public long? GasTypeId { get; set; }
        public long? WireTypeId { get; set; }
        public long? WireScrewId { get; set; }
        public decimal? WireThickness { get; set; }
        public decimal? WireConsumption { get; set; }
        public long? PowderTypeId { get; set; }
        public Project Project { get; set; }

        public ProjectDetail(long partId, string partCode, long? gasTypeId, long? wireTypeId, long? wireScrewId,
            decimal? wireThickness, decimal? wireConsumption, long? powderTypeId)
        {
            Guid = Guid.NewGuid();
            PartId = partId;
            PartCode = partCode;
            GasTypeId = gasTypeId;
            WireTypeId = wireTypeId;
            WireScrewId = wireScrewId;
            WireThickness = wireThickness;
            WireConsumption = wireConsumption;
            PowderTypeId = powderTypeId;
        }

        public void Edit(long partId, string partCode, long? gasTypeId, long? wireTypeId, long? wireScrewId, decimal? wireThickness,
            decimal? wireConsumption, long? powderTypeId)
        {
            PartId = partId;
            PartCode = partCode;
            GasTypeId = gasTypeId;
            WireTypeId = wireTypeId;
            WireScrewId = wireScrewId;
            WireThickness = wireThickness;
            WireConsumption = wireConsumption;
            PowderTypeId = powderTypeId;
        }
    }
}
