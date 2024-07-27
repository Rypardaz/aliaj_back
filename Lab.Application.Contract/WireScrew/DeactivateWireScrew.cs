using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WireScrew
{
    public class DeactivateWireScrew : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivateWireScrew(Guid guid)
        {
            Guid = guid;
        }
    }

}
