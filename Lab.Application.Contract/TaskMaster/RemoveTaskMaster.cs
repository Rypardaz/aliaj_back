using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.TaskMaster
{
    public class RemoveTaskMaster : ICommand
    {
        public Guid Guid { get; set; }
        public RemoveTaskMaster(Guid guid)
        {
            Guid = guid;
        }
    }
}
