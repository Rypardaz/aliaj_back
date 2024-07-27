using Ex.Domain.PowderTypeAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.PowderTypeAgg
{
    public class PowderType : AuditableAggregateRootBase<long>
    {
        public long PowderTypeGroupId { get; set; }
        public string Name { get; set; }

        protected PowderType() { }

        public PowderType(Guid creator, long powderTypeGroupId, string name, IPowderTypeService service) :
        base(creator)
        {
            service.ThrowWhenDuplicatedName(powderTypeGroupId, name);

            PowderTypeGroupId = powderTypeGroupId;
            Name = name;
        }

        public void Edit(Guid actor, long powderTypeGroupId, string name, IPowderTypeService service)
        {
            service.ThrowWhenDuplicatedName(powderTypeGroupId, name, Id);

            PowderTypeGroupId = powderTypeGroupId;
            Name = name;

            Modified(actor);
        }
    }
}
