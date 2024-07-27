using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Project
{
    public class RemoveProject : ICommand
    {
        public Guid Guid { get; set; }

        public RemoveProject(Guid guid)
        {
            Guid = guid;
        }
    }
}