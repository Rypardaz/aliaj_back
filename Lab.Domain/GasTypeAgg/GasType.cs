using Ex.Domain.GasTypeAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.GasTypeAgg
{
    public class GasType : AuditableAggregateRootBase<long>
    {
        public  long GasTypeGroupId { get; set; }
        public string Name { get; set; }

        protected GasType() { }

        public GasType(Guid creator, long gasTypeGroupId, string name, IGasTypeService service) :
        base(creator)
        {
            service.ThrowWhenDuplicatedName(gasTypeGroupId, name);

            GasTypeGroupId = gasTypeGroupId;
            Name = name;
        }

        public void Edit(Guid actor, long gasTypeGroupId, string name, IGasTypeService service)
        {
            service.ThrowWhenDuplicatedName(gasTypeGroupId, name, Id);

            GasTypeGroupId = gasTypeGroupId;
            Name = name;

            Modified(actor);
        }
    }
}
