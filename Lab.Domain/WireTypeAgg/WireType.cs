using Ex.Domain.WireTypeAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.WireTypeAgg
{
    public class WireType : AuditableAggregateRootBase<long>
    {
        public long WireTypeGroupId { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; }
        public decimal? WireSize { get; set; }

        protected WireType() { }

        public WireType(Guid creator, long wireTypeGroupId, string? code, string name, decimal? wireSize, IWireTypeService service) :
        base(creator)
        {
            WireTypeGroupId = wireTypeGroupId;
            Code = code;
            Name = name;
            WireSize = wireSize;
        }

        public void Edit(Guid actor, long wireTypeGroupId, string? code, string name, decimal? wireSize, IWireTypeService service)
        {
            WireTypeGroupId = wireTypeGroupId;
            Code = code;
            Name = name;
            WireSize = wireSize;

            Modified(actor);
        }
    }
}
