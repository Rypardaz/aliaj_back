using Ex.Domain.GasTypeGroupAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.GasTypeGroupAgg
{
    public class GasTypeGroup : AuditableAggregateRootBase<long>
    {
        public string Name { get; set; }

        protected GasTypeGroup() { }

        public GasTypeGroup(Guid creator, string name, IGasTypeGroupService service) :
        base(creator)
        {
            service.ThrowWhenDuplicatedName(name);

            Name = name;
        }

        public void Edit(Guid actor, string name, IGasTypeGroupService service)
        {
            service.ThrowWhenDuplicatedName(name, Id);

            Name = name;

            Modified(actor);
        }
    }
}
