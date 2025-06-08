using PhoenixFramework.Domain;

namespace Ex.Domain.DailyRecordAgg
{
    public record DailyRecordDetail : ValueObjectBase
    {
        public long Id { get; private set; }
        public Guid Guid { get; private set; }
        public long DailyRecordId { get; private set; }
        public long PersonnelId { get; private set; }
        public long? ProjectDetailId { get; private set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public long ActivityId { get; private set; }
        public long? GasTypeId { get; private set; }
        public long? PowderTypeId { get; private set; }
        public long? WireTypeId { get; private set; }
        public long? WireScrewId { get; private set; }
        public decimal? WireConsumption { get; private set; }
        public string? ProducedScrew { get; private set; }
        public decimal? ProducedWire { get; private set; }
        public long? ProducedWireTypeId { get; private set; }
        public DailyRecord DailyRecord { get; private set; }

        public DailyRecordDetail(long dailyRecordId, long personnelId, long? projectDetailId, string startTime,
            string endTime, long activityId, decimal? wireConsumption, string? producedScrew, decimal? producedWire)
        {
            Guid = Guid.NewGuid();
            DailyRecordId = dailyRecordId;
            PersonnelId = personnelId;
            ProjectDetailId = projectDetailId;
            StartTime = startTime;
            EndTime = endTime;
            ActivityId = activityId;
            WireConsumption = wireConsumption;
            ProducedScrew = producedScrew;
            ProducedWire = producedWire;
        }

        public void SetGasTypeId(long? gasTypeId)
        {
            GasTypeId = gasTypeId;
        }

        public void SetPowderTypeId(long? powderTypeId)
        {
            PowderTypeId = powderTypeId;
        }

        public void SetWireTypeId(long? wireTypeId)
        {
            WireTypeId = wireTypeId;
        }

        public void SetProducedWireTypeId(long? producedWireTypeId)
        {
            ProducedWireTypeId = producedWireTypeId;
        }

        public void SetWireScrewId(long? wireScrewId)
        {
            WireScrewId = wireScrewId;
        }
    }
}