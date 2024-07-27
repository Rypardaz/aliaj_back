using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WireType
{
    public class ActivateWireType : ICommand
    {
        public Guid Guid { get; set; }

        public ActivateWireType(Guid guid)
        {
            Guid = guid;
        }
    }
}
