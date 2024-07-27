using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.TaskMaster
{
    public class ActivateTaskMaster : ICommand
    {
        public Guid Guid { get; set; }

        public ActivateTaskMaster(Guid guid)
        {
            Guid = guid;
        }
    }
}
