using Ex.Domain.PartAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.PartAgg
{
    public class Part : AuditableAggregateRootBase<long>
    {
        public long PartGroupId { get; set; }
        public string Name { get; set; }
        public decimal? StandardWireConsumption { get; set; }

        protected Part() { }

        public Part(Guid creator, long partGroupId, string name, decimal? standardWireConsumption, IPartService service) :
        base(creator)
        {
            service.ThrowWhenDuplicatedName(partGroupId, name);

            PartGroupId = partGroupId;
            Name = name;
            StandardWireConsumption = standardWireConsumption;
        }

        public void Edit(Guid actor, long partGroupId, string name, decimal? standardWireConsumption, IPartService service)
        {
            service.ThrowWhenDuplicatedName(partGroupId, name, Id);

            PartGroupId = partGroupId;
            Name = name;
            StandardWireConsumption = standardWireConsumption;

            Modified(actor);
        }
    }
}
