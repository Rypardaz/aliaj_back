using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Machine
{
    public class ActivateMachine : ICommand
    {
        public Guid Guid { get; set; }

        public ActivateMachine(Guid guid)
        {
            Guid = guid;
        }
    }
}
