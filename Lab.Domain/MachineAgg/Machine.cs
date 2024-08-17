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
        public string? Description { get; set; }
        public string? Ip { get; private set; }

        protected Machine()
        {
        }

        public Machine(Guid creator, string code, string name, long? salonId, byte headCount, string? description,
            string? ip, IMachineService service) : base(creator)
        {
            service.ThrowWhenDuplicatedCode(code);
            service.ThrowWhenDuplicatedName(name);

            Code = code;
            Name = name;
            SalonId = salonId;
            HeadCount = headCount;
            Description = description;
            Ip = ip;
        }

        public void Edit(Guid actor, string code, string name, long? salonId, byte headCount, string? description,
            string? ip, IMachineService service)
        {
            service.ThrowWhenDuplicatedCode(code, Id);
            service.ThrowWhenDuplicatedName(name, Id);

            Code = code;
            Name = name;
            SalonId = salonId;
            HeadCount = headCount;
            Description = description;
            Ip = ip;

            Modified(actor);
        }
    }
}