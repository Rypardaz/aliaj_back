using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.ProjectType
{
    public class ActivateProjectType : ICommand
    {
        public Guid Guid { get; set; }

        public ActivateProjectType(Guid guid)
        {
            Guid = guid;
        }
    }
}
