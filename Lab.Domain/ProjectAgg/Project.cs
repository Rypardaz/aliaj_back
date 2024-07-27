using Ex.Domain.ProjectAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.ProjectAgg
{
    public class Project : AuditableAggregateRootBase<long>
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public long TaskMasterId { get; private set; }
        public long ProjectTypeId { get; private set; }
        public long SalonId { get; private set; }
        public string DeliveryDate { get; private set; }
        public string? Description { get; private set; }
        public List<ProjectDetail> Details { get; private set; }

        protected Project()
        {
        }

        public Project(Guid creator, string code, string name, long taskMasterId, long projectTypeId,
            long salonId, string deliveryDate, int isActive, string? description, IProjectService projectService) 
            : base(creator)
        {
            Code = code;
            Name = name;
            TaskMasterId = taskMasterId;
            ProjectTypeId = projectTypeId;
            SalonId = salonId;
            DeliveryDate = deliveryDate;
            Description = description;

            SetActivation(isActive);
        }

        public void Edit(Guid actor, string code, string name, long taskMasterId, long projectTypeId,
            long salonId, string deliveryDate, int isActive, string? description, IProjectService projectService)
        {
            Code = code;
            Name = name;
            TaskMasterId = taskMasterId;
            ProjectTypeId = projectTypeId;
            SalonId = salonId;
            DeliveryDate = deliveryDate;
            Description = description;

            SetActivation(isActive);
            Modified(actor);
        }

        public void AddDetail(ProjectDetail detail)
        {
            Details ??= new();
            Details.Add(detail);
        }
    }
}
