using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WireType
{
    public class RemoveWireType : ICommand
    {
        public Guid Guid { get; set; }
        public RemoveWireType(Guid guid)
        {
            Guid = guid;
        }
    }
}
