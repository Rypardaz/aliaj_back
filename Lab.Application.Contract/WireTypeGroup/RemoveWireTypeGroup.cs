using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WireTypeGroup
{
    public class RemoveWireTypeGroup : ICommand
    {
        public Guid Guid { get; set; }
        public RemoveWireTypeGroup(Guid guid)
        {
            Guid = guid;
        }
    }

}
