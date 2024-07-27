using Ex.Domain.PartGroupAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.PartGroupAgg
{
    public class PartGroup : AuditableAggregateRootBase<long>
    {
        public string Name { get; set; }

        protected PartGroup() {}

        public PartGroup(Guid creator, string name, IPartGroupService service) :
        base(creator)
        {
            service.ThrowWhenDuplicatedName(name);

            Name = name;
        }

        public void Edit(Guid actor, string name, IPartGroupService service)
        {
            service.ThrowWhenDuplicatedName(name, Id);

            Name = name;

            Modified(actor);
        }
    }
}
