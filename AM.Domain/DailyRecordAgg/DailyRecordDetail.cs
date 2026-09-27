using PhoenixFramework.Domain;

namespace AM.Domain.DailyRecordAgg;

public record DailyRecordDetail(
    long DailyRecordId,
    long PersonnelId,
    long? ProjectDetailId,
    string StartTime,
    string EndTime,
    long ActivityId,
    decimal? WireConsumption,
    string? ProducedScrew,
    decimal? ProducedWire)
    : ValueObjectBase
{
    public long Id { get; private set; }
    public Guid Guid { get; private set; } = Guid.NewGuid();
    public long DailyRecordId { get; private set; } = DailyRecordId;
    public long PersonnelId { get; private set; } = PersonnelId;
    public long? ProjectDetailId { get; private set; } = ProjectDetailId;
    public string StartTime { get; set; } = StartTime;
    public string EndTime { get; set; } = EndTime;
    public long ActivityId { get; private set; } = ActivityId;
    public long? GasTypeId { get; private set; }
    public long? PowderTypeId { get; private set; }
    public long? WireTypeId { get; private set; }
    public long? WireScrewId { get; private set; }
    public decimal? WireConsumption { get; private set; } = WireConsumption;
    public string? ProducedScrew { get; private set; } = ProducedScrew;
    public decimal? ProducedWire { get; private set; } = ProducedWire;
    public long? ProducedWireTypeId { get; private set; }
    public DailyRecord DailyRecord { get; private set; }

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