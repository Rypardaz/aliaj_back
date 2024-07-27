using Ex.Domain.ProjectTypeAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.ProjectTypeAgg
{
    public class ProjectType : AuditableAggregateRootBase<long>
    {
        public string Name { get; set; }
        public long SalonId { get; set; }

        protected ProjectType() { }

        public ProjectType(Guid creator, string name, long salonId, IProjectTypeService service) :
        base(creator)
        {
            service.ThrowWhenDuplicatedName(salonId, name);

            Name = name;
            SalonId = salonId;
        }

        public void Edit(Guid actor, string name, long salonId, IProjectTypeService service)
        {
            service.ThrowWhenDuplicatedName(SalonId, name, Id);

            Name = name;
            SalonId = salonId;

            Modified(actor);
        }
    }
}
