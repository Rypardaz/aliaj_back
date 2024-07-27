using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.Project
{
    public class ProjectViewModel : ViewModelAbilities
    {
        public Guid Guid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string TaskMasterName { get; set; }
        public string ProjectTypeName { get; set; }
        public string SalonName { get; set; }
        public string DeliveryDate { get; set; }
        public string? Description { get; set; }
        public string IsActive { get; set; }
        public string Created { get; set; }
    }
}
