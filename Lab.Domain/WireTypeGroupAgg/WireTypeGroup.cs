using Ex.Domain.WireTypeGroupAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.WireTypeGroupAgg
{
    public class WireTypeGroup : AuditableAggregateRootBase<long>
    {
        public string Name { get; set; }

        protected WireTypeGroup() { }

        public WireTypeGroup(Guid creator, string name, IWireTypeGroupService service) :
        base(creator)
        {
            service.ThrowWhenDuplicatedName(name);

            Name = name;
        }

        public void Edit(Guid actor, string name, IWireTypeGroupService service)
        {
            service.ThrowWhenDuplicatedName(name, Id);

            Name = name;

            Modified(actor);
        }
    }
}
