using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.ProjectType
{
    public class DeactivateProjectType : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivateProjectType(Guid guid)
        {
            Guid = guid;
        }
    }
}
