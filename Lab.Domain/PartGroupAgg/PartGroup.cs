using PhoenixFramework.Domain;
using Ex.Domain.PartGroupAgg.Service;

namespace Ex.Domain.PartGroupAgg;

public class PartGroup : AuditableAggregateRootBase<long>
{
    public string Name { get; set; }
    public long SalonId { get; set; }

    protected PartGroup()
    {
    }

    public PartGroup(Guid creator, string name, long salonId, IPartGroupService service) : base(creator)
    {
        service.ThrowWhenDuplicatedName(name);

        Name = name;
        SalonId = salonId;
    }

    public void Edit(Guid actor, string name, long salonId, IPartGroupService service)
    {
        service.ThrowWhenDuplicatedName(name, Id);

        Name = name;
        SalonId = salonId;

        Modified(actor);
    }
}