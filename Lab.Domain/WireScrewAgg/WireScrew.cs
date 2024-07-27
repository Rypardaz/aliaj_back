using Ex.Domain.WireScrewAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.WireScrewAgg
{
    public class WireScrew : AuditableAggregateRootBase<long>
    {
        public long WireTypeId { get; set; }
        public int Screw { get; set; }
        public  decimal Qty { get; set; }

        protected WireScrew() { }

        public WireScrew(Guid creator, long wireTypeId, int screw, decimal qty, IWireScrewService service) :
        base(creator)
        {
            service.ThrowWhenDuplicatedScrew(wireTypeId, screw);

            WireTypeId = wireTypeId;
            Screw = screw;
            Qty = qty;
        }

        public void Edit(Guid actor, long wireTypeId, int screw, decimal qty, IWireScrewService service)
        {
            service.ThrowWhenDuplicatedScrew(wireTypeId, screw, Id);

            WireTypeId = wireTypeId;
            Screw = screw;
            Qty = qty;

            Modified(actor);
        }
    }
}
