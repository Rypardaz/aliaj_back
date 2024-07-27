using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WireScrew
{
    public class RemoveWireScrew : ICommand
    {
        public Guid Guid { get; set; }
        public RemoveWireScrew(Guid guid)
        {
            Guid = guid;
        }
    }

}
