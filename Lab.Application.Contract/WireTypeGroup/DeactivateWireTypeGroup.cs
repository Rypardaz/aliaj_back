using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WireTypeGroup
{
    public class DeactivateWireTypeGroup : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivateWireTypeGroup(Guid guid)
        {
            Guid = guid;
        }
    }

}
