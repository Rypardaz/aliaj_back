using Ex.Domain.MachineAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.MachineAgg
{
    public class Machine : AuditableAggregateRootBase<long>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public long? SalonId { get; set; }
        public byte HeadCount { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }

        protected Machine() { }

        public Machine(Guid creator, string code, string name, long? salonId, byte headCount, int capacity, string? description, IMachineService service) :
        base(creator)
        {
            service.ThrowWhenDuplicatedCode(code);
            service.ThrowWhenDuplicatedName(name);

            Code = code;
            Name = name;
            SalonId = salonId;
            HeadCount = headCount;
            Capacity = capacity;
            Description = description;
        }

        public void Edit(Guid actor, string code, string name, long? salonId, byte headCount, int capacity, string? description, IMachineService service)
        {
            service.ThrowWhenDuplicatedCode(code, Id);
            service.ThrowWhenDuplicatedName(name, Id);

            Code = code;
            Name = name;
            SalonId = salonId;
            HeadCount = headCount;
            Capacity = capacity;
            Description = description;

            Modified(actor);
        }
    }
}
