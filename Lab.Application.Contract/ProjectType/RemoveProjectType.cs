using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.ProjectType
{
    public class RemoveProjectType : ICommand
    {
        public Guid Guid { get; set; }
        public RemoveProjectType(Guid guid)
        {
            Guid = guid;
        }
    }
}
