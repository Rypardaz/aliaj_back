using Ex.Domain.WireTypeAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.WireTypeAgg
{
    public class WireType : AuditableAggregateRootBase<long>
    {
        public long WireTypeGroupId { get; set; }
        public string Name { get; private set; }
        public decimal? WireSize { get; private set; }
        public int? SourceGuid { get; private set; }

        protected WireType() { }

        public WireType(Guid creator, long wireTypeGroupId, string name, decimal? wireSize, int? sourceGuid, IWireTypeService service) :
        base(creator)
        {
            WireTypeGroupId = wireTypeGroupId;
            Name = name;
            WireSize = wireSize;
            SourceGuid = sourceGuid;
        }

        public void Edit(Guid actor, long wireTypeGroupId, string name, decimal? wireSize, int? sourceGuid, IWireTypeService service)
        {
            WireTypeGroupId = wireTypeGroupId;
            Name = name;
            WireSize = wireSize;
            SourceGuid = sourceGuid;

            Modified(actor);
        }
    }
}
