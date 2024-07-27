using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WireType
{
    public class DeactivateWireType : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivateWireType(Guid guid)
        {
            Guid = guid;
        }
    }
}
