using Ex.Domain.PowderTypeGroupAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.PowderTypeGroupAgg
{
    public class PowderTypeGroup : AuditableAggregateRootBase<long>
    {
        public string Name { get; set; }

        protected PowderTypeGroup() { }

        public PowderTypeGroup(Guid creator, string name, IPowderTypeGroupService service) :
        base(creator)
        {
            service.ThrowWhenDuplicatedName(name);

            Name = name;
        }

        public void Edit(Guid actor, string name, IPowderTypeGroupService service)
        {
            service.ThrowWhenDuplicatedName(name, Id);

            Name = name;

            Modified(actor);
        }
    }
}
