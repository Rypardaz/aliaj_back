using Ex.Domain.WireTypeAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.WireTypeAgg
{
    public class WireType : AuditableAggregateRootBase<long>
    {
        public long WireTypeGroupId { get; set; }
        public string Name { get; private set; }
        public decimal? WireSize { get; private set; }

        protected WireType() { }

        public WireType(Guid creator, long wireTypeGroupId, string name, decimal? wireSize, IWireTypeService service) :
        base(creator)
        {
            service.ThrowWhenDuplicatedName(wireTypeGroupId, name);

            WireTypeGroupId = wireTypeGroupId;
            Name = name;
            WireSize = wireSize;
        }

        public void Edit(Guid actor, long wireTypeGroupId, string name, decimal? wireSize, IWireTypeService service)
        {
            service.ThrowWhenDuplicatedName(wireTypeGroupId, name, Id);

            WireTypeGroupId = wireTypeGroupId;
            Name = name;
            WireSize = wireSize;

            Modified(actor);
        }
    }
}
