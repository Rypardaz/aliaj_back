using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Machine
{
    public class DeactivateMachine : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivateMachine(Guid guid)
        {
            Guid = guid;
        }
    }
}
