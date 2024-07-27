using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.TaskMaster
{
    public class DeactivateTaskMaster : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivateTaskMaster(Guid guid)
        {
            Guid = guid;
        }
    }
}
