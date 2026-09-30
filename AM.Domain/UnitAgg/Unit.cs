using AM.Domain.UnitAgg.Service;
using PhoenixFramework.Domain;

namespace AM.Domain.UnitAgg;

public class Unit : AuditableAggregateRootBase<long>
{
    public string Code { get; private set; }
    public string Name { get; private set; }

    protected Unit()
    {
    }

    public Unit(Guid creator, string code, string name, IUnitService service) : base(creator)
    {
        service.ThrowWhenDuplicatedName(code);
        service.ThrowWhenDuplicatedName(name);

        Code = code;
        Name = name;
    }

    public void Edit(Guid actor, string code, string name, IUnitService service)
    {
        service.ThrowWhenDuplicatedName(code, Id);
        service.ThrowWhenDuplicatedName(name, Id);

        Code = code;
        Name = name;

        Modified(actor);
    }
}