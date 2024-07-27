using Ex.Domain.SalonAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.SalonAgg
{
    public class Salon : AuditableAggregateRootBase<long>
    {
        public string Name { get; private set; }
        public bool HasGas { get; private set; }
        public bool HasWire { get; private set; }
        public bool HasWireScrew { get; private set; }
        public bool HasPowder { get; private set; }

        protected Salon() { }

        public Salon(Guid creator, string name, bool hasGas, bool hasWire, bool hasWireScrew, bool hasPowder,
            ISalonService service) : base(creator)
        {
            service.ThrowWhenDuplicatedName(name);

            Name = name;
            HasGas = hasGas;
            HasWire = hasWire;
            HasWireScrew = hasWireScrew;
            HasPowder = hasPowder;
        }

        public void Edit(Guid actor, string name, bool hasGas, bool hasWire, bool hasWireScrew
            , bool hasPowder, ISalonService service)
        {
            service.ThrowWhenDuplicatedName(name, Id);

            Name = name;
            HasGas = hasGas;
            HasWire = hasWire;
            HasWireScrew = hasWireScrew;
            HasPowder = hasPowder;

            Modified(actor);
        }
    }
}
