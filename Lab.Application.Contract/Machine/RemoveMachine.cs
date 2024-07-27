using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Machine
{
    public class RemoveMachine : ICommand
    {
        public Guid Guid { get; set; }
        public RemoveMachine(Guid guid)
        {
            Guid = guid;
        }
    }
}
