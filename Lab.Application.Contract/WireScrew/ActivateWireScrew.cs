using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WireScrew
{
    public class ActivateWireScrew : ICommand
    {
        public Guid Guid { get; set; }

        public ActivateWireScrew(Guid guid)
        {
            Guid = guid;
        }
    }

}
