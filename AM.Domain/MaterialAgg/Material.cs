using AM.Domain.MaterialAgg.Service;
using PhoenixFramework.Domain;

namespace AM.Domain.MaterialAgg;

public class Material : AuditableAggregateRootBase<long>
{
    public long UnitId { get; set; }
    public string Code { get; private set; }
    public string Name { get; private set; }

    protected Material()
    {
    }

    public Material(Guid creator, long unitId, string code, string name, IMaterialService service) : base(creator)
    {
        service.ThrowWhenDuplicatedName(code);
        service.ThrowWhenDuplicatedName(name);

        UnitId = unitId;
        Code = code;
        Name = name;
    }

    public void Edit(Guid actor, long unitId, string code, string name, IMaterialService service)
    {
        service.ThrowWhenDuplicatedName(code, Id);
        service.ThrowWhenDuplicatedName(name, Id);

        UnitId = unitId;
        Code = code;
        Name = name;

        Modified(actor);
    }
}
