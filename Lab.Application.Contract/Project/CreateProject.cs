using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Project
{
    public class CreateProject : ICommand
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid TaskMasterGuid { get; set; }
        public Guid ProjectTypeGuid { get; set; }
        public Guid SalonGuid { get; set; }
        public string DeliveryDate { get; set; }
        public string? Description { get; set; }
        public Guid? ReplacementWireTypeGuid { get; set; }
        public Guid IsActive { get; set; }
        public List<ProjectDetailOperations> Details { get; set; }
    }
}