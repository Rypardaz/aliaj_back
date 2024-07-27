using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WireTypeGroup
{
    public class ActivateWireTypeGroup : ICommand
    {
        public Guid Guid { get; set; }

        public ActivateWireTypeGroup(Guid guid)
        {
            Guid = guid;
        }
    }

}
