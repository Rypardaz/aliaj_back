using Ex.Domain.ActivityAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.ActivityAgg;

public class Activity : AuditableAggregateRootBase<long>
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public int Type { get; private set; }
    public int SubType { get; private set; }
    public int? SourceId { get; private set; }
    public bool IsOther { get; set; }
    public List<ActivitySalon> Salons { get; private set; }

    protected Activity()
    {
    }

    public Activity(Guid creator, string code, string name, int type, int subType, int? sourceId, bool isOther,
        List<long> salonIds, IActivityService service) : base(creator)
    {
        service.ThrowWhenDuplicatedName(name);

        Code = code;
        Name = name;
        Type = type;
        SubType = subType;
        SourceId = sourceId;
        IsOther = isOther;
        Salons = salonIds.Select(x => new ActivitySalon { SalonId = x, ActivityId = Id }).ToList();
    }

    public void Edit(Guid actor, string code, string name, int type, int subType, int? sourceId, bool isOther,
        List<long> salonIds, IActivityService service)
    {
        service.ThrowWhenDuplicatedName(name, Id);

        Code = code;
        Name = name;
        Type = type;
        SubType = subType;
        SourceId = sourceId;
        IsOther = isOther;
        Salons = salonIds.Select(x => new ActivitySalon { SalonId = x, ActivityId = Id }).ToList();

        Modified(actor);
    }
}